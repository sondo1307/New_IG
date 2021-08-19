#pragma once
#include "BaseState.h"
#include "ClosedState.h"
#include "OpenedState.h"
class LockedState : public BaseState {
public:
	void Open(StateContext* sc)override;
	void Close(StateContext* sc)override;
	void Lock(StateContext* sc)override;
	void Unlock(StateContext* sc)override;
};