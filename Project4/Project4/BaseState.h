#pragma once

class StateContext;

class BaseState {
public:
	virtual void Open(StateContext* sc) = 0;
	virtual void Close(StateContext* sc) = 0;
	virtual void Lock(StateContext* sc) = 0;
	virtual void Unlock(StateContext* sc) = 0;
};