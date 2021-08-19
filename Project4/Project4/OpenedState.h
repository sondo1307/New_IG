#pragma once
#include"BaseState.h"

class OpenedState : public BaseState
{
public:
	void Open(StateContext* bs) override;
	void Close(StateContext* bs) override;
	void Unlock(StateContext* bs) override;
	void Lock(StateContext* bs) override;
};