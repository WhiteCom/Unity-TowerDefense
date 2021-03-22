#pragma once

struct MyPoint
{
	float x, y;

	bool operator == (const MyPoint& p);
	bool operator != (const MyPoint& p);

	MyPoint operator + (const float p);
	MyPoint operator - (const float p);
	MyPoint operator * (const float p);
	MyPoint operator / (const float p);

	MyPoint& operator += (const float p);
	MyPoint& operator -= (const float p);
	MyPoint& operator *= (const float p);
	MyPoint& operator /= (const float p);

	MyPoint operator + (const MyPoint& p);
	MyPoint operator - (const MyPoint& p);
	MyPoint operator * (const MyPoint& p);
	MyPoint operator / (const MyPoint& p);

	MyPoint& operator += (const MyPoint p);
	MyPoint& operator -= (const MyPoint p);
	MyPoint& operator *= (const MyPoint p);
	MyPoint& operator /= (const MyPoint p);
};

#define MyPointZero MyPointMake(0.0f, 0.0f);

MyPoint MyPointMake(float x, float y);