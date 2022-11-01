using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GbSnd.SndInterop;
using static SDL2.SDL;

namespace GbSnd
{
    internal class Demo
    {
        int volume;
        int delay = 0;
        public void run()
        {
            if (SDL_Init(SDL_INIT_AUDIO) < 0)
                return;

            if (SoundInit(44100, 2) != null)
                return;

            bool res = SampleRate(44100);

            if (res)
                return;

            // Generate a few seconds of sound
            for (int n = 60 * 4; n > 0; n--)
            {
                // Simulate emulation of 1/60 second frame
                emulate_frame();

                // Samples from the frame can now be read out of the apu, or
                // allowed to accumulate and read out later. Use samples_avail()
                // to find out how many samples are currently in the buffer.

                int buf_size = 2048;
                short[] buf = new short[buf_size];

                // Play whatever samples are available
                long count = ReadSamples(buf, buf_size);
                SoundWrite(buf, count);
            }

            SDL_Quit();
        }

        void emulate_frame()
        {
            Random rand = new();

            if (--delay <= 0)
            {
                delay = 12;

                // Start a new random tone
                int chan = rand.Next(0, 255) & 0x11;
                WriteReg(0xff26, 0x80);
                WriteReg(0xff25, chan > 0 ? chan : 0x11);
                WriteReg(0xff11, 0x80);
                int freq = (rand.Next(0, 255) & 0x3ff) + 0x300;
                WriteReg(0xff13, freq & 0xff);
                WriteReg(0xff12, 0xf1);
                WriteReg(0xff14, (freq >> 8) | 0x80);
            }

            // Generate 1/60 second of sound into APU's sample buffer
            EndFrame();
        }
    }
}
