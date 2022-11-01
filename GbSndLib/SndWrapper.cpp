#include "SndWrapper.h"

static Basic_Gb_Apu apu;
static Sound_Queue sound;
static Wave_Writer wave(44100);

void gb_write_reg(gb_addr_t addr, int data)
{
    apu.write_register(addr, data);
}

bool gb_sample_rate(long rate)
{
    return apu.set_sample_rate(rate);
}

void gb_end_frame()
{
    apu.end_frame();
}

long gb_read_samples(blip_sample_t* out, long count)
{
    return apu.read_samples(out, count);
}

const char* gb_sound_init(long sample_rate, int chan_count)
{
    const char* res = sound.start(sample_rate, chan_count);
    return res;
}

void gb_sound_write(const short* in, int count)
{
    sound.write(in, count);
}

void gb_play_samples(short* samples, long count)
{
    wave.write(samples, count);
}
