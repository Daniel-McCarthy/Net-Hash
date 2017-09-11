#include <iostream>
#include <string>
#include"FNV.h"


using namespace std;

int main()
{

	unsigned char testInput[] = { 72, 101, 108, 108, 111, 75, 105, 116, 116, 121 };

	int fnv0Hash = FNV::fnv0_32Hash(testInput, 10);

	cout << to_string(fnv0Hash) << endl;

	cin.get();
}

