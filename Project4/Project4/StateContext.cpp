#include"StateContext.h"


StateContext::StateContext() {
	m_BaseState = new OpenedState();
}

void StateContext::SetState(BaseState* bs) {
	m_BaseState = bs;
}

void StateContext::Open() {
	m_BaseState->Open(this);
}

void StateContext::Close() {
	m_BaseState->Close(this);
}

void StateContext::Lock() {
	m_BaseState->Lock(this);
}

void StateContext::Unlock() {
	m_BaseState->Unlock(this);
}