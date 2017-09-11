#pragma once

static class FNV
{
public:

	static const unsigned int fnv032Prime = 16777619;
	static const unsigned int fnv132Prime = 16777619;
	static const unsigned int fnv132Offset = 0x811C9DC5;

	static int fnv0_32Hash(unsigned char message[], int inputLength);
};

