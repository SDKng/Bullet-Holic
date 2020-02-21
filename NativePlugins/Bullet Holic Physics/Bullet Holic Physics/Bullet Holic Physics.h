// The following ifdef block is the standard way of creating macros which make exporting
// from a DLL simpler. All files within this DLL are compiled with the BULLETHOLICPHYSICS_EXPORTS
// symbol defined on the command line. This symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see
// BULLETHOLICPHYSICS_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.
#ifdef BULLETHOLICPHYSICS_EXPORTS
#define BULLETHOLICPHYSICS_API __declspec(dllexport)
#else
#define BULLETHOLICPHYSICS_API __declspec(dllimport)
#endif

// This class is exported from the dll
class BULLETHOLICPHYSICS_API CBulletHolicPhysics {
public:
	CBulletHolicPhysics(void);

	// TODO: add your methods here.
};

extern BULLETHOLICPHYSICS_API int nBulletHolicPhysics;

BULLETHOLICPHYSICS_API int fnBulletHolicPhysics(void);
