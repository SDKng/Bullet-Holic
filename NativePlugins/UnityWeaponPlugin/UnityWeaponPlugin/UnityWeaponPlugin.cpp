#include "IUnityGraphics.h"

#include "d3d11.h"

#include "IUnityGraphicsD3D11.h"

//debug event
typedef void(*Funcptr)(const char *);
Funcptr Debug;

namespace globals {
	ID3D11Device *device = nullptr;
	ID3D11DeviceContext *context = nullptr;
}

extern "C" {
	UNITY_INTERFACE_EXPORT void SetDebugFuction(Funcptr fp) { Debug = fp; }

	//plugin function to handle a specific rendering event
	static void UNITY_INTERFACE_API OnRenderEvent(int eventid) {
		Debug("hello world");
	}

	//unity plugin load event
	void UNITY_INTERFACE_EXPORT UNITY_INTERFACE_API UnityPluginLoad(IUnityInterfaces *unityInterfaces) {
		auto s_unityInterfaces = unityInterfaces;
		IUnityGraphicsD3D11 *d3d11 = unityInterfaces->Get<IUnityGraphicsD3D11>();
		globals::device = d3d11->GetDevice();
		globals::device->GetImmediateContext(&globals::context);
	}

	//unity plugin unload event
	void UNITY_INTERFACE_EXPORT UNITY_INTERFACE_API UnityPluginUnload(){}

	//freely defined function to pass a callback to plugin specific scripts
	UnityRenderingEvent UNITY_INTERFACE_EXPORT UNITY_INTERFACE_API getEventFunction() {
		return OnRenderEvent;
	}

}
