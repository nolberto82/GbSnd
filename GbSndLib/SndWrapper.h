#pragma once

#include "gb_apu_emu/Basic_Gb_Apu.h"
#include "gb_apu_emu/Sound_Queue.h"
#include "gb_apu_emu/Wave_Writer.h"

extern "C"
{
	//__declspec(dllexport) Simple_Apu* New_Nes_Apu();
	//__declspec(dllexport) void Delete_Nes_Apu(Simple_Apu* apu);
	__declspec(dllexport) void gb_write_reg(gb_addr_t addr, int data);
	//__declspec(dllexport) void nes_dmc_reader(int (*f)(void* user_data, cpu_addr_t), void* p);
	__declspec(dllexport) bool gb_sample_rate(long rate);
	__declspec(dllexport) void gb_end_frame();
	__declspec(dllexport) long gb_read_samples(blip_sample_t* p, long s);
	__declspec(dllexport) const char* gb_sound_init(long sample_rate, int chan_count = 1);
	__declspec(dllexport) void gb_sound_write(const short* in, int count);
	__declspec(dllexport) void gb_play_samples(short* samples, long count);
}