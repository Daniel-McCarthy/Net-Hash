#include "FNV.h"

#include <iostream>




int FNV::fnv0_32Hash(unsigned char message[], int inputLength)
{
	int hash = 0;

	for (int i = 0; i < inputLength; i++)
	{
		hash *= fnv032Prime;
		hash ^= message[i];
	}

	return hash;

}
