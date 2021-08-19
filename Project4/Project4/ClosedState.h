#pragma once
#include "BaseState.h"
#include "OpenedState.h"
#include "LockedState.h"
class ClosedState : public BaseState{
public:
	void Open(StateContext* sc)override;
	void Close(StateContext* sc)override;
	void Lock(StateContext* sc)override;
	void Unlock(StateContext* sc)override;
};