// WinAPI.cpp : 애플리케이션에 대한 진입점을 정의합니다.
//
#include "../Resource.h"
#include "MainApp.h"
#include "MyStd.h"

#define MAX_LOADSTRING 100

// 전역 변수
bool runWindow = false;
HWND hWnd;
HDC hDC; //그리기용
HINSTANCE hInst;                                
WCHAR szTitle[MAX_LOADSTRING] = TEXT("TEST1");  
WCHAR szWindowClass[MAX_LOADSTRING] = TEXT("TEST2");

LRESULT CALLBACK    WndProc(HWND, UINT, WPARAM, LPARAM);

int APIENTRY wWinMain(_In_ HINSTANCE hInstance,
                     _In_opt_ HINSTANCE hPrevInstance,
                     _In_ LPWSTR    lpCmdLine,
                     _In_ int       nCmdShow)
{
    UNREFERENCED_PARAMETER(hPrevInstance);
    UNREFERENCED_PARAMETER(lpCmdLine);

    // TODO: 여기에 코드를 입력합니다.

    WNDCLASSEXW wcex;

    wcex.cbSize = sizeof(WNDCLASSEX);

    wcex.style = CS_HREDRAW | CS_VREDRAW;
    wcex.lpfnWndProc = WndProc;
    wcex.cbClsExtra = 0;
    wcex.cbWndExtra = 0;
    wcex.hInstance = hInstance;
    wcex.hIcon = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_WINAPI));
    wcex.hCursor = LoadCursor(nullptr, IDC_ARROW);
    wcex.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);
    wcex.lpszMenuName = MAKEINTRESOURCEW(IDC_WINAPI);
    wcex.lpszClassName = szWindowClass;
    wcex.hIconSm = LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

    RegisterClassExW(&wcex);

    hInst = hInstance; // 인스턴스 핸들을 전역 변수에 저장합니다.

    hWnd = CreateWindowW(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW,
        CW_USEDEFAULT, 0, CW_USEDEFAULT, 0, nullptr, nullptr, hInstance, nullptr);

    if (hWnd == NULL)
    {
        return FALSE;
    }

    hDC = GetDC(hWnd);
    ShowWindow(hWnd, nCmdShow);
    UpdateWindow(hWnd);


    MSG msg;

    // 기본 메시지 루프입니다:
    for (runWindow = true;runWindow;)
    {
        if (PeekMessage(&msg, NULL, 0, 0, PM_REMOVE))
        {
            TranslateMessage(&msg);
            DispatchMessage(&msg);
        }
        else
        {
            mainLoop(hDC);
            SwapBuffers(hDC);
        }
    }

    return (int) msg.wParam;
}

void mainLoop(HDC hDC)
{
    RECT rt;
    GetClientRect(hWnd, &rt);
    Rectangle(hDC, rt.left + 5, rt.top + 5, rt.right - 5, rt.bottom - 5);

    //RECT rect = { 100, 100, 300, 200 };
    //const wchar_t* str = L"Test";
    //DrawText(hDC, str, -1, &rect, DT_CENTER | DT_WORDBREAK);

}

LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
    switch (message)
    {
    case WM_CLOSE:
    {
        runWindow = false;
    }
    case WM_DESTROY:
        PostQuitMessage(0);
        return 0;
    }
    return DefWindowProc(hWnd, message, wParam, lParam);
}
