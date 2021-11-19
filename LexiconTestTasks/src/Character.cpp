#include <iostream>
#include <random>
#include "Character.h"

Character::Character(const std::wstring name)
{
	this->name = name;
	randomizeCharacteristics();
}

void Character::print()
{
	std::wcout << L"Namn: " << name << std::endl
		<< L" Hälsa: " << health << std::endl
		<< L" Styrka: " << strength << std::endl
		<< L" Tur: " << luck << std::endl;
}

uint32_t Character::genRand(uint32_t min, uint32_t max)
{
	return (std::rand() % (max - min + 1) + min);
}

void Character::randomizeCharacteristics()
{
	health = genRand(10, 30);
	strength = genRand(5, 15);
	luck = genRand(2, 8);
}
