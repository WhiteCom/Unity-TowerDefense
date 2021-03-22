#include "MyPoint.h"

bool MyPoint::operator == (const MyPoint& p)
{
	return x == p.x && y == p.y;
}
bool MyPoint::operator != (const MyPoint& p)
{
	return x != p.x || y != p.y;
}

MyPoint MyPoint::operator + (const float p)
{
	MyPoint t;
	t.x = x + p;
	t.y = y + p;
	return t;
}

MyPoint MyPoint::operator - (const float p)
{
	MyPoint t;
	t.x = x - p;
	t.y = y - p;
	return t;
}
MyPoint MyPoint::operator * (const float p)
{
	MyPoint t;
	t.x = x * p;
	t.y = y * p;
	return t;
}
MyPoint MyPoint::operator / (const float p)
{
	MyPoint t;
	t.x = x / p;
	t.y = y / p;
	return t;
}

MyPoint& MyPoint::operator += (const float p)
{
	x += p;
	y += p;
	return *this;
}

MyPoint& MyPoint::operator -= (const float p)
{
	x -= p;
	y -= p;
	return *this;
}

MyPoint& MyPoint::operator *= (const float p)
{
	x *= p;
	y *= p;
	return *this;
}

MyPoint& MyPoint::operator /= (const float p)
{
	x /= p;
	y /= p;
	return *this;
}

MyPoint MyPoint::operator + (const MyPoint& p)
{
	MyPoint t;
	t.x = x + p.x;
	t.y = y + p.y;
	return t;
}

MyPoint MyPoint::operator - (const MyPoint& p)
{
	MyPoint t;
	t.x = x - p.x;
	t.y = y - p.y;
	return t;
}

MyPoint MyPoint::operator * (const MyPoint& p)
{
	MyPoint t;
	t.x = x * p.x;
	t.y = y * p.y;
	return t;
}

MyPoint MyPoint::operator / (const MyPoint& p)
{
	MyPoint t;
	t.x = x / p.x;
	t.y = y / p.y;
	return t;
}

MyPoint& MyPoint::operator += (const MyPoint p)
{
	x += p.x;
	y += p.y;
	return *this;
}

MyPoint& MyPoint::operator -= (const MyPoint p)
{
	x -= p.x;
	y -= p.y;
	return *this;
}
MyPoint& MyPoint::operator *= (const MyPoint p)
{
	x *= p.x;
	y *= p.y;
	return *this;
}
MyPoint& MyPoint::operator /= (const MyPoint p)
{
	x /= p.x;
	y /= p.y;
	return *this;
}

MyPoint MyPointMake(float x, float y)
{
	MyPoint p;
	p.x = x;
	p.y = y;
	return p;
}