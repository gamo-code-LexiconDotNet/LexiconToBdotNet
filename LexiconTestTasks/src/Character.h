#pragma once

#include <string>

class Character
{
public:
	Character(const std::wstring);
	void print();
protected:
	std::wstring name;
	uint32_t health;
	uint32_t strength;
	uint32_t luck;
private:
	uint32_t genRand(uint32_t, uint32_t);
	void randomizeCharacteristics();
};