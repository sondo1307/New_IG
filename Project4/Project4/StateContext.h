#pragma once
#include "BaseState.h"
#include"OpenedState.h"

class BaseState;

class StateContext {
protected:
	BaseState* m_BaseState;
public:
	StateContext();
	void SetState(BaseState* bs);
	void Open();
	void Close();
	void Lock();
	void Unlock();
};
