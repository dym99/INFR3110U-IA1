// dllmain.cpp : Defines the entry point for the DLL application.
#define _CRT_SECURE_NO_WARNINGS
#include <Windows.h>
#include <stdio.h>
#include <string.h>
#include <direct.h>

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{	
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}

#define API __declspec(dllexport)

extern "C" {

	static int err = 0;

	API bool save(char* path, char* filename, float x, float y, float z) {
		_mkdir(path);
		strcat(path, filename);
		FILE* file = fopen(path, "w");
		if (file == NULL) {
			//File failed to open
			err = 1;
			return false;
		}
		else {
			fprintf(file, "%f,%f,%f", x, y, z);
			fclose(file);
			return true;
		}
	}

	API bool load(char *path, char* filename, float& x, float& y, float& z) {
		strcat(path, filename);
		FILE* file = fopen(path, "r");
		if (file == NULL) {
			//File failed to open
			err = 2;
			return false;
		}
		else {
			fscanf_s(file, "%f,%f,%f", &x, &y, &z);
			fclose(file);
			return true;
		}
	}

	API int getError() { return err; }

}