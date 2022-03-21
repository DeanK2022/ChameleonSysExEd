typedef unsigned char   undefined;

typedef unsigned int    ImageBaseOffset32;
typedef unsigned char    bool;
typedef unsigned char    byte;
typedef unsigned int    dword;
float10
typedef unsigned char    uchar;
typedef unsigned int    uint;
typedef unsigned long    ulong;
typedef unsigned char    undefined1;
typedef unsigned short    undefined2;
typedef unsigned int    undefined4;
typedef unsigned long long    undefined8;
typedef unsigned short    ushort;
typedef short    wchar_t;
typedef unsigned short    word;
#define unkbyte9   unsigned long long
#define unkbyte10   unsigned long long
#define unkbyte11   unsigned long long
#define unkbyte12   unsigned long long
#define unkbyte13   unsigned long long
#define unkbyte14   unsigned long long
#define unkbyte15   unsigned long long
#define unkbyte16   unsigned long long

#define unkuint9   unsigned long long
#define unkuint10   unsigned long long
#define unkuint11   unsigned long long
#define unkuint12   unsigned long long
#define unkuint13   unsigned long long
#define unkuint14   unsigned long long
#define unkuint15   unsigned long long
#define unkuint16   unsigned long long

#define unkint9   long long
#define unkint10   long long
#define unkint11   long long
#define unkint12   long long
#define unkint13   long long
#define unkint14   long long
#define unkint15   long long
#define unkint16   long long

#define unkfloat1   float
#define unkfloat2   float
#define unkfloat3   float
#define unkfloat5   double
#define unkfloat6   double
#define unkfloat7   double
#define unkfloat9   long double
#define unkfloat11   long double
#define unkfloat12   long double
#define unkfloat13   long double
#define unkfloat14   long double
#define unkfloat15   long double
#define unkfloat16   long double

#define BADSPACEBASE   void
#define code   void

typedef unsigned short    wchar16;
typedef union IMAGE_RESOURCE_DIRECTORY_ENTRY_DirectoryUnion IMAGE_RESOURCE_DIRECTORY_ENTRY_DirectoryUnion, *PIMAGE_RESOURCE_DIRECTORY_ENTRY_DirectoryUnion;

typedef struct IMAGE_RESOURCE_DIRECTORY_ENTRY_DirectoryStruct IMAGE_RESOURCE_DIRECTORY_ENTRY_DirectoryStruct, *PIMAGE_RESOURCE_DIRECTORY_ENTRY_DirectoryStruct;

struct IMAGE_RESOURCE_DIRECTORY_ENTRY_DirectoryStruct {
    dword OffsetToDirectory;
    dword DataIsDirectory;
};

union IMAGE_RESOURCE_DIRECTORY_ENTRY_DirectoryUnion {
    dword OffsetToData;
    struct IMAGE_RESOURCE_DIRECTORY_ENTRY_DirectoryStruct IMAGE_RESOURCE_DIRECTORY_ENTRY_DirectoryStruct;
};

typedef struct tagMENUITEMINFOA tagMENUITEMINFOA, *PtagMENUITEMINFOA;

typedef struct tagMENUITEMINFOA MENUITEMINFOA;

typedef uint UINT;

typedef struct HMENU__ HMENU__, *PHMENU__;

typedef struct HMENU__ * HMENU;

typedef struct HBITMAP__ HBITMAP__, *PHBITMAP__;

typedef struct HBITMAP__ * HBITMAP;

typedef ulong ULONG_PTR;

typedef char CHAR;

typedef CHAR * LPSTR;

struct tagMENUITEMINFOA {
    UINT cbSize;
    UINT fMask;
    UINT fType;
    UINT fState;
    UINT wID;
    HMENU hSubMenu;
    HBITMAP hbmpChecked;
    HBITMAP hbmpUnchecked;
    ULONG_PTR dwItemData;
    LPSTR dwTypeData;
    UINT cch;
    HBITMAP hbmpItem;
};

struct HMENU__ {
    int unused;
};

struct HBITMAP__ {
    int unused;
};

typedef struct tagWINDOWPLACEMENT tagWINDOWPLACEMENT, *PtagWINDOWPLACEMENT;

typedef struct tagWINDOWPLACEMENT WINDOWPLACEMENT;

typedef struct tagPOINT tagPOINT, *PtagPOINT;

typedef struct tagPOINT POINT;

typedef struct tagRECT tagRECT, *PtagRECT;

typedef struct tagRECT RECT;

typedef long LONG;

struct tagPOINT {
    LONG x;
    LONG y;
};

struct tagRECT {
    LONG left;
    LONG top;
    LONG right;
    LONG bottom;
};

struct tagWINDOWPLACEMENT {
    UINT length;
    UINT flags;
    UINT showCmd;
    POINT ptMinPosition;
    POINT ptMaxPosition;
    RECT rcNormalPosition;
};

typedef struct tagWNDCLASSA tagWNDCLASSA, *PtagWNDCLASSA;

typedef long LONG_PTR;

typedef LONG_PTR LRESULT;

typedef struct HWND__ HWND__, *PHWND__;

typedef struct HWND__ * HWND;

typedef uint UINT_PTR;

typedef UINT_PTR WPARAM;

typedef LONG_PTR LPARAM;

typedef LRESULT (* WNDPROC)(HWND, UINT, WPARAM, LPARAM);

typedef struct HINSTANCE__ HINSTANCE__, *PHINSTANCE__;

typedef struct HINSTANCE__ * HINSTANCE;

typedef struct HICON__ HICON__, *PHICON__;

typedef struct HICON__ * HICON;

typedef HICON HCURSOR;

typedef struct HBRUSH__ HBRUSH__, *PHBRUSH__;

typedef struct HBRUSH__ * HBRUSH;

typedef CHAR * LPCSTR;

struct HBRUSH__ {
    int unused;
};

struct tagWNDCLASSA {
    UINT style;
    WNDPROC lpfnWndProc;
    int cbClsExtra;
    int cbWndExtra;
    HINSTANCE hInstance;
    HICON hIcon;
    HCURSOR hCursor;
    HBRUSH hbrBackground;
    LPCSTR lpszMenuName;
    LPCSTR lpszClassName;
};

struct HICON__ {
    int unused;
};

struct HINSTANCE__ {
    int unused;
};

struct HWND__ {
    int unused;
};

typedef struct tagMSG tagMSG, *PtagMSG;

typedef struct tagMSG MSG;

typedef ulong DWORD;

struct tagMSG {
    HWND hwnd;
    UINT message;
    WPARAM wParam;
    LPARAM lParam;
    DWORD time;
    POINT pt;
};

typedef struct tagMSG * LPMSG;

typedef struct _ICONINFO _ICONINFO, *P_ICONINFO;

typedef struct _ICONINFO ICONINFO;

typedef int BOOL;

struct _ICONINFO {
    BOOL fIcon;
    DWORD xHotspot;
    DWORD yHotspot;
    HBITMAP hbmMask;
    HBITMAP hbmColor;
};

typedef MENUITEMINFOA * LPCMENUITEMINFOA;

typedef struct tagSCROLLINFO tagSCROLLINFO, *PtagSCROLLINFO;

struct tagSCROLLINFO {
    UINT cbSize;
    UINT fMask;
    int nMin;
    int nMax;
    UINT nPage;
    int nPos;
    int nTrackPos;
};

typedef struct tagSCROLLINFO SCROLLINFO;

typedef struct tagMENUITEMINFOA * LPMENUITEMINFOA;

typedef LRESULT (* HOOKPROC)(int, WPARAM, LPARAM);

typedef SCROLLINFO * LPCSCROLLINFO;

typedef struct tagWNDCLASSA WNDCLASSA;

typedef struct tagPAINTSTRUCT tagPAINTSTRUCT, *PtagPAINTSTRUCT;

typedef struct tagPAINTSTRUCT * LPPAINTSTRUCT;

typedef struct HDC__ HDC__, *PHDC__;

typedef struct HDC__ * HDC;

typedef uchar BYTE;

struct HDC__ {
    int unused;
};

struct tagPAINTSTRUCT {
    HDC hdc;
    BOOL fErase;
    RECT rcPaint;
    BOOL fRestore;
    BOOL fIncUpdate;
    BYTE rgbReserved[32];
};

typedef ICONINFO * PICONINFO;

typedef struct tagPAINTSTRUCT PAINTSTRUCT;

typedef struct tagSCROLLINFO * LPSCROLLINFO;

typedef BOOL (* WNDENUMPROC)(HWND, LPARAM);

typedef void (* TIMERPROC)(HWND, UINT, UINT_PTR, DWORD);

typedef struct tagWNDCLASSA * LPWNDCLASSA;

typedef struct tagRGBQUAD tagRGBQUAD, *PtagRGBQUAD;

typedef struct tagRGBQUAD RGBQUAD;

struct tagRGBQUAD {
    BYTE rgbBlue;
    BYTE rgbGreen;
    BYTE rgbRed;
    BYTE rgbReserved;
};

typedef struct tagLOGFONTA tagLOGFONTA, *PtagLOGFONTA;

struct tagLOGFONTA {
    LONG lfHeight;
    LONG lfWidth;
    LONG lfEscapement;
    LONG lfOrientation;
    LONG lfWeight;
    BYTE lfItalic;
    BYTE lfUnderline;
    BYTE lfStrikeOut;
    BYTE lfCharSet;
    BYTE lfOutPrecision;
    BYTE lfClipPrecision;
    BYTE lfQuality;
    BYTE lfPitchAndFamily;
    CHAR lfFaceName[32];
};

typedef struct tagLOGBRUSH tagLOGBRUSH, *PtagLOGBRUSH;

typedef DWORD COLORREF;

struct tagLOGBRUSH {
    UINT lbStyle;
    COLORREF lbColor;
    ULONG_PTR lbHatch;
};

typedef struct tagTEXTMETRICA tagTEXTMETRICA, *PtagTEXTMETRICA;

struct tagTEXTMETRICA {
    LONG tmHeight;
    LONG tmAscent;
    LONG tmDescent;
    LONG tmInternalLeading;
    LONG tmExternalLeading;
    LONG tmAveCharWidth;
    LONG tmMaxCharWidth;
    LONG tmWeight;
    LONG tmOverhang;
    LONG tmDigitizedAspectX;
    LONG tmDigitizedAspectY;
    BYTE tmFirstChar;
    BYTE tmLastChar;
    BYTE tmDefaultChar;
    BYTE tmBreakChar;
    BYTE tmItalic;
    BYTE tmUnderlined;
    BYTE tmStruckOut;
    BYTE tmPitchAndFamily;
    BYTE tmCharSet;
};

typedef struct tagLOGPEN tagLOGPEN, *PtagLOGPEN;

typedef struct tagLOGPEN LOGPEN;

struct tagLOGPEN {
    UINT lopnStyle;
    POINT lopnWidth;
    COLORREF lopnColor;
};

typedef struct tagBITMAPINFO tagBITMAPINFO, *PtagBITMAPINFO;

typedef struct tagBITMAPINFOHEADER tagBITMAPINFOHEADER, *PtagBITMAPINFOHEADER;

typedef struct tagBITMAPINFOHEADER BITMAPINFOHEADER;

typedef ushort WORD;

struct tagBITMAPINFOHEADER {
    DWORD biSize;
    LONG biWidth;
    LONG biHeight;
    WORD biPlanes;
    WORD biBitCount;
    DWORD biCompression;
    DWORD biSizeImage;
    LONG biXPelsPerMeter;
    LONG biYPelsPerMeter;
    DWORD biClrUsed;
    DWORD biClrImportant;
};

struct tagBITMAPINFO {
    BITMAPINFOHEADER bmiHeader;
    RGBQUAD bmiColors[1];
};

typedef struct tagMETAFILEPICT tagMETAFILEPICT, *PtagMETAFILEPICT;

typedef struct tagMETAFILEPICT METAFILEPICT;

typedef struct HMETAFILE__ HMETAFILE__, *PHMETAFILE__;

typedef struct HMETAFILE__ * HMETAFILE;

struct tagMETAFILEPICT {
    LONG mm;
    LONG xExt;
    LONG yExt;
    HMETAFILE hMF;
};

struct HMETAFILE__ {
    int unused;
};

typedef struct tagENHMETAHEADER tagENHMETAHEADER, *PtagENHMETAHEADER;

typedef struct tagENHMETAHEADER * LPENHMETAHEADER;

typedef struct _RECTL _RECTL, *P_RECTL;

typedef struct _RECTL RECTL;

typedef struct tagSIZE tagSIZE, *PtagSIZE;

typedef struct tagSIZE SIZE;

typedef SIZE SIZEL;

struct tagSIZE {
    LONG cx;
    LONG cy;
};

struct _RECTL {
    LONG left;
    LONG top;
    LONG right;
    LONG bottom;
};

struct tagENHMETAHEADER {
    DWORD iType;
    DWORD nSize;
    RECTL rclBounds;
    RECTL rclFrame;
    DWORD dSignature;
    DWORD nVersion;
    DWORD nBytes;
    DWORD nRecords;
    WORD nHandles;
    WORD sReserved;
    DWORD nDescription;
    DWORD offDescription;
    DWORD nPalEntries;
    SIZEL szlDevice;
    SIZEL szlMillimeters;
    DWORD cbPixelFormat;
    DWORD offPixelFormat;
    DWORD bOpenGL;
    SIZEL szlMicrometers;
};

typedef struct tagBITMAPINFO BITMAPINFO;

typedef struct tagPALETTEENTRY tagPALETTEENTRY, *PtagPALETTEENTRY;

struct tagPALETTEENTRY {
    BYTE peRed;
    BYTE peGreen;
    BYTE peBlue;
    BYTE peFlags;
};

typedef struct tagLOGPALETTE tagLOGPALETTE, *PtagLOGPALETTE;

typedef struct tagLOGPALETTE LOGPALETTE;

typedef struct tagPALETTEENTRY PALETTEENTRY;

struct tagLOGPALETTE {
    WORD palVersion;
    WORD palNumEntries;
    PALETTEENTRY palPalEntry[1];
};

typedef struct tagBITMAPINFO * LPBITMAPINFO;

typedef struct tagLOGBRUSH LOGBRUSH;

typedef struct tagLOGFONTA LOGFONTA;

typedef struct tagPALETTEENTRY * LPPALETTEENTRY;

typedef struct tagTEXTMETRICA * LPTEXTMETRICA;

typedef struct _GUID _GUID, *P_GUID;

struct _GUID {
    ulong Data1;
    ushort Data2;
    ushort Data3;
    uchar Data4[8];
};

typedef struct _GUID GUID;

typedef GUID IID;

typedef GUID CLSID;

typedef struct _cpinfo _cpinfo, *P_cpinfo;

struct _cpinfo {
    UINT MaxCharSize;
    BYTE DefaultChar[2];
    BYTE LeadByte[12];
};

typedef BOOL (* CALINFO_ENUMPROCA)(LPSTR);

typedef struct _cpinfo * LPCPINFO;

typedef DWORD LCTYPE;

typedef DWORD CALID;

typedef DWORD CALTYPE;

typedef struct _SYSTEM_INFO _SYSTEM_INFO, *P_SYSTEM_INFO;

typedef struct _SYSTEM_INFO * LPSYSTEM_INFO;

typedef union _union_530 _union_530, *P_union_530;

typedef void * LPVOID;

typedef ULONG_PTR DWORD_PTR;

typedef struct _struct_531 _struct_531, *P_struct_531;

struct _struct_531 {
    WORD wProcessorArchitecture;
    WORD wReserved;
};

union _union_530 {
    DWORD dwOemId;
    struct _struct_531 s;
};

struct _SYSTEM_INFO {
    union _union_530 u;
    DWORD dwPageSize;
    LPVOID lpMinimumApplicationAddress;
    LPVOID lpMaximumApplicationAddress;
    DWORD_PTR dwActiveProcessorMask;
    DWORD dwNumberOfProcessors;
    DWORD dwProcessorType;
    DWORD dwAllocationGranularity;
    WORD wProcessorLevel;
    WORD wProcessorRevision;
};

typedef struct _OVERLAPPED _OVERLAPPED, *P_OVERLAPPED;

typedef union _union_518 _union_518, *P_union_518;

typedef void * HANDLE;

typedef struct _struct_519 _struct_519, *P_struct_519;

typedef void * PVOID;

struct _struct_519 {
    DWORD Offset;
    DWORD OffsetHigh;
};

union _union_518 {
    struct _struct_519 s;
    PVOID Pointer;
};

struct _OVERLAPPED {
    ULONG_PTR Internal;
    ULONG_PTR InternalHigh;
    union _union_518 u;
    HANDLE hEvent;
};

typedef struct _SECURITY_ATTRIBUTES _SECURITY_ATTRIBUTES, *P_SECURITY_ATTRIBUTES;

struct _SECURITY_ATTRIBUTES {
    DWORD nLength;
    LPVOID lpSecurityDescriptor;
    BOOL bInheritHandle;
};

typedef struct _SYSTEMTIME _SYSTEMTIME, *P_SYSTEMTIME;

typedef struct _SYSTEMTIME SYSTEMTIME;

struct _SYSTEMTIME {
    WORD wYear;
    WORD wMonth;
    WORD wDayOfWeek;
    WORD wDay;
    WORD wHour;
    WORD wMinute;
    WORD wSecond;
    WORD wMilliseconds;
};

typedef struct _WIN32_FIND_DATAA _WIN32_FIND_DATAA, *P_WIN32_FIND_DATAA;

typedef struct _FILETIME _FILETIME, *P_FILETIME;

typedef struct _FILETIME FILETIME;

struct _FILETIME {
    DWORD dwLowDateTime;
    DWORD dwHighDateTime;
};

struct _WIN32_FIND_DATAA {
    DWORD dwFileAttributes;
    FILETIME ftCreationTime;
    FILETIME ftLastAccessTime;
    FILETIME ftLastWriteTime;
    DWORD nFileSizeHigh;
    DWORD nFileSizeLow;
    DWORD dwReserved0;
    DWORD dwReserved1;
    CHAR cFileName[260];
    CHAR cAlternateFileName[14];
};

typedef DWORD (* PTHREAD_START_ROUTINE)(LPVOID);

typedef PTHREAD_START_ROUTINE LPTHREAD_START_ROUTINE;

typedef struct _OVERLAPPED * LPOVERLAPPED;

typedef struct _SECURITY_ATTRIBUTES * LPSECURITY_ATTRIBUTES;

typedef struct _STARTUPINFOA _STARTUPINFOA, *P_STARTUPINFOA;

typedef BYTE * LPBYTE;

struct _STARTUPINFOA {
    DWORD cb;
    LPSTR lpReserved;
    LPSTR lpDesktop;
    LPSTR lpTitle;
    DWORD dwX;
    DWORD dwY;
    DWORD dwXSize;
    DWORD dwYSize;
    DWORD dwXCountChars;
    DWORD dwYCountChars;
    DWORD dwFillAttribute;
    DWORD dwFlags;
    WORD wShowWindow;
    WORD cbReserved2;
    LPBYTE lpReserved2;
    HANDLE hStdInput;
    HANDLE hStdOutput;
    HANDLE hStdError;
};

typedef struct _WIN32_FIND_DATAA * LPWIN32_FIND_DATAA;

typedef struct _STARTUPINFOA * LPSTARTUPINFOA;

typedef struct _RTL_CRITICAL_SECTION _RTL_CRITICAL_SECTION, *P_RTL_CRITICAL_SECTION;

typedef struct _RTL_CRITICAL_SECTION * PRTL_CRITICAL_SECTION;

typedef PRTL_CRITICAL_SECTION LPCRITICAL_SECTION;

typedef struct _RTL_CRITICAL_SECTION_DEBUG _RTL_CRITICAL_SECTION_DEBUG, *P_RTL_CRITICAL_SECTION_DEBUG;

typedef struct _RTL_CRITICAL_SECTION_DEBUG * PRTL_CRITICAL_SECTION_DEBUG;

typedef struct _LIST_ENTRY _LIST_ENTRY, *P_LIST_ENTRY;

typedef struct _LIST_ENTRY LIST_ENTRY;

struct _RTL_CRITICAL_SECTION {
    PRTL_CRITICAL_SECTION_DEBUG DebugInfo;
    LONG LockCount;
    LONG RecursionCount;
    HANDLE OwningThread;
    HANDLE LockSemaphore;
    ULONG_PTR SpinCount;
};

struct _LIST_ENTRY {
    struct _LIST_ENTRY * Flink;
    struct _LIST_ENTRY * Blink;
};

struct _RTL_CRITICAL_SECTION_DEBUG {
    WORD Type;
    WORD CreatorBackTraceIndex;
    struct _RTL_CRITICAL_SECTION * CriticalSection;
    LIST_ENTRY ProcessLocksList;
    DWORD EntryCount;
    DWORD ContentionCount;
    DWORD Flags;
    WORD CreatorBackTraceIndexHigh;
    WORD SpareWORD;
};

typedef struct _SYSTEMTIME * LPSYSTEMTIME;

typedef struct _MEMORY_BASIC_INFORMATION _MEMORY_BASIC_INFORMATION, *P_MEMORY_BASIC_INFORMATION;

typedef ULONG_PTR SIZE_T;

struct _MEMORY_BASIC_INFORMATION {
    PVOID BaseAddress;
    PVOID AllocationBase;
    DWORD AllocationProtect;
    SIZE_T RegionSize;
    DWORD State;
    DWORD Protect;
    DWORD Type;
};

typedef struct _CONTEXT _CONTEXT, *P_CONTEXT;

typedef struct _CONTEXT CONTEXT;

typedef struct _FLOATING_SAVE_AREA _FLOATING_SAVE_AREA, *P_FLOATING_SAVE_AREA;

typedef struct _FLOATING_SAVE_AREA FLOATING_SAVE_AREA;

struct _FLOATING_SAVE_AREA {
    DWORD ControlWord;
    DWORD StatusWord;
    DWORD TagWord;
    DWORD ErrorOffset;
    DWORD ErrorSelector;
    DWORD DataOffset;
    DWORD DataSelector;
    BYTE RegisterArea[80];
    DWORD Cr0NpxState;
};

struct _CONTEXT {
    DWORD ContextFlags;
    DWORD Dr0;
    DWORD Dr1;
    DWORD Dr2;
    DWORD Dr3;
    DWORD Dr6;
    DWORD Dr7;
    FLOATING_SAVE_AREA FloatSave;
    DWORD SegGs;
    DWORD SegFs;
    DWORD SegEs;
    DWORD SegDs;
    DWORD Edi;
    DWORD Esi;
    DWORD Ebx;
    DWORD Edx;
    DWORD Ecx;
    DWORD Eax;
    DWORD Ebp;
    DWORD Eip;
    DWORD SegCs;
    DWORD EFlags;
    DWORD Esp;
    DWORD SegSs;
    BYTE ExtendedRegisters[512];
};

typedef union _ULARGE_INTEGER _ULARGE_INTEGER, *P_ULARGE_INTEGER;

typedef union _ULARGE_INTEGER ULARGE_INTEGER;

typedef struct _struct_22 _struct_22, *P_struct_22;

typedef struct _struct_23 _struct_23, *P_struct_23;

typedef double ULONGLONG;

struct _struct_23 {
    DWORD LowPart;
    DWORD HighPart;
};

struct _struct_22 {
    DWORD LowPart;
    DWORD HighPart;
};

union _ULARGE_INTEGER {
    struct _struct_22 s;
    struct _struct_23 u;
    ULONGLONG QuadPart;
};

typedef struct _EXCEPTION_RECORD _EXCEPTION_RECORD, *P_EXCEPTION_RECORD;

typedef struct _EXCEPTION_RECORD EXCEPTION_RECORD;

typedef EXCEPTION_RECORD * PEXCEPTION_RECORD;

struct _EXCEPTION_RECORD {
    DWORD ExceptionCode;
    DWORD ExceptionFlags;
    struct _EXCEPTION_RECORD * ExceptionRecord;
    PVOID ExceptionAddress;
    DWORD NumberParameters;
    ULONG_PTR ExceptionInformation[15];
};

typedef union _LARGE_INTEGER _LARGE_INTEGER, *P_LARGE_INTEGER;

typedef struct _struct_19 _struct_19, *P_struct_19;

typedef struct _struct_20 _struct_20, *P_struct_20;

typedef double LONGLONG;

struct _struct_20 {
    DWORD LowPart;
    LONG HighPart;
};

struct _struct_19 {
    DWORD LowPart;
    LONG HighPart;
};

union _LARGE_INTEGER {
    struct _struct_19 s;
    struct _struct_20 u;
    LONGLONG QuadPart;
};

typedef wchar_t WCHAR;

typedef WCHAR * LPWSTR;

typedef WCHAR * LPCWSTR;

typedef long HRESULT;

typedef struct _MEMORY_BASIC_INFORMATION * PMEMORY_BASIC_INFORMATION;

typedef LONG * PLONG;

typedef struct _OSVERSIONINFOA _OSVERSIONINFOA, *P_OSVERSIONINFOA;

struct _OSVERSIONINFOA {
    DWORD dwOSVersionInfoSize;
    DWORD dwMajorVersion;
    DWORD dwMinorVersion;
    DWORD dwBuildNumber;
    DWORD dwPlatformId;
    CHAR szCSDVersion[128];
};

typedef union _LARGE_INTEGER LARGE_INTEGER;

typedef struct _OSVERSIONINFOA * LPOSVERSIONINFOA;

typedef CONTEXT * PCONTEXT;

typedef short SHORT;

typedef DWORD ACCESS_MASK;

typedef DWORD LCID;

typedef CHAR * PCNZCH;

typedef struct IMAGE_DOS_HEADER IMAGE_DOS_HEADER, *PIMAGE_DOS_HEADER;

struct IMAGE_DOS_HEADER {
    char e_magic[2]; // Magic number
    word e_cblp; // Bytes of last page
    word e_cp; // Pages in file
    word e_crlc; // Relocations
    word e_cparhdr; // Size of header in paragraphs
    word e_minalloc; // Minimum extra paragraphs needed
    word e_maxalloc; // Maximum extra paragraphs needed
    word e_ss; // Initial (relative) SS value
    word e_sp; // Initial SP value
    word e_csum; // Checksum
    word e_ip; // Initial IP value
    word e_cs; // Initial (relative) CS value
    word e_lfarlc; // File address of relocation table
    word e_ovno; // Overlay number
    word e_res[4][4]; // Reserved words
    word e_oemid; // OEM identifier (for e_oeminfo)
    word e_oeminfo; // OEM information; e_oemid specific
    word e_res2[10][10]; // Reserved words
    dword e_lfanew; // File address of new exe header
    byte e_program[192]; // Actual DOS program
};

typedef struct tagFUNCDESC tagFUNCDESC, *PtagFUNCDESC;

typedef LONG DISPID;

typedef DISPID MEMBERID;

typedef LONG SCODE;

typedef struct tagELEMDESC tagELEMDESC, *PtagELEMDESC;

typedef struct tagELEMDESC ELEMDESC;

typedef enum tagFUNCKIND {
    FUNC_VIRTUAL=0,
    FUNC_NONVIRTUAL=2,
    FUNC_PUREVIRTUAL=1,
    FUNC_STATIC=3,
    FUNC_DISPATCH=4
} tagFUNCKIND;

typedef enum tagFUNCKIND FUNCKIND;

typedef enum tagINVOKEKIND {
    INVOKE_FUNC=1,
    INVOKE_PROPERTYPUT=4,
    INVOKE_PROPERTYGET=2,
    INVOKE_PROPERTYPUTREF=8
} tagINVOKEKIND;

typedef enum tagINVOKEKIND INVOKEKIND;

typedef enum tagCALLCONV {
    CC_CDECL=1,
    CC_MPWCDECL=8,
    CC_FPFASTCALL=6,
    CC_MAX=10,
    CC_MACPASCAL=4,
    CC_FASTCALL=0,
    CC_MPWPASCAL=9,
    CC_STDCALL=5,
    CC_MSCPASCAL=2,
    CC_SYSCALL=7,
    CC_PASCAL=3
} tagCALLCONV;

typedef enum tagCALLCONV CALLCONV;

typedef struct tagTYPEDESC tagTYPEDESC, *PtagTYPEDESC;

typedef struct tagTYPEDESC TYPEDESC;

typedef union _union_2702 _union_2702, *P_union_2702;

typedef union _union_2691 _union_2691, *P_union_2691;

typedef ushort VARTYPE;

typedef struct tagIDLDESC tagIDLDESC, *PtagIDLDESC;

typedef struct tagIDLDESC IDLDESC;

typedef struct tagPARAMDESC tagPARAMDESC, *PtagPARAMDESC;

typedef struct tagPARAMDESC PARAMDESC;

typedef struct tagARRAYDESC tagARRAYDESC, *PtagARRAYDESC;

typedef DWORD HREFTYPE;

typedef ushort USHORT;

typedef struct tagPARAMDESCEX tagPARAMDESCEX, *PtagPARAMDESCEX;

typedef struct tagPARAMDESCEX * LPPARAMDESCEX;

typedef struct tagSAFEARRAYBOUND tagSAFEARRAYBOUND, *PtagSAFEARRAYBOUND;

typedef struct tagSAFEARRAYBOUND SAFEARRAYBOUND;

typedef DWORD ULONG;

typedef struct tagVARIANT tagVARIANT, *PtagVARIANT;

typedef struct tagVARIANT VARIANT;

typedef VARIANT VARIANTARG;

typedef union _union_2683 _union_2683, *P_union_2683;

typedef struct __tagVARIANT __tagVARIANT, *P__tagVARIANT;

typedef struct tagDEC tagDEC, *PtagDEC;

typedef struct tagDEC DECIMAL;

typedef union _union_2685 _union_2685, *P_union_2685;

typedef union _union_1695 _union_1695, *P_union_1695;

typedef union _union_1697 _union_1697, *P_union_1697;

typedef float FLOAT;

typedef double DOUBLE;

typedef short VARIANT_BOOL;

typedef union tagCY tagCY, *PtagCY;

typedef union tagCY CY;

typedef double DATE;

typedef WCHAR OLECHAR;

typedef OLECHAR * BSTR;

typedef struct IUnknown IUnknown, *PIUnknown;

typedef struct IDispatch IDispatch, *PIDispatch;

typedef struct tagSAFEARRAY tagSAFEARRAY, *PtagSAFEARRAY;

typedef struct tagSAFEARRAY SAFEARRAY;

typedef int INT;

typedef struct __tagBRECORD __tagBRECORD, *P__tagBRECORD;

typedef struct _struct_1696 _struct_1696, *P_struct_1696;

typedef struct _struct_1698 _struct_1698, *P_struct_1698;

typedef struct _struct_1693 _struct_1693, *P_struct_1693;

typedef struct IUnknownVtbl IUnknownVtbl, *PIUnknownVtbl;

typedef struct IDispatchVtbl IDispatchVtbl, *PIDispatchVtbl;

typedef struct ITypeInfo ITypeInfo, *PITypeInfo;

typedef OLECHAR * LPOLESTR;

typedef struct tagDISPPARAMS tagDISPPARAMS, *PtagDISPPARAMS;

typedef struct tagDISPPARAMS DISPPARAMS;

typedef struct tagEXCEPINFO tagEXCEPINFO, *PtagEXCEPINFO;

typedef struct tagEXCEPINFO EXCEPINFO;

typedef struct IRecordInfo IRecordInfo, *PIRecordInfo;

typedef struct ITypeInfoVtbl ITypeInfoVtbl, *PITypeInfoVtbl;

typedef struct tagTYPEATTR tagTYPEATTR, *PtagTYPEATTR;

typedef struct tagTYPEATTR TYPEATTR;

typedef struct ITypeComp ITypeComp, *PITypeComp;

typedef struct tagFUNCDESC FUNCDESC;

typedef struct tagVARDESC tagVARDESC, *PtagVARDESC;

typedef struct tagVARDESC VARDESC;

typedef struct ITypeLib ITypeLib, *PITypeLib;

typedef struct IRecordInfoVtbl IRecordInfoVtbl, *PIRecordInfoVtbl;

typedef OLECHAR * LPCOLESTR;

typedef enum tagTYPEKIND {
    TKIND_ALIAS=6,
    TKIND_MAX=8,
    TKIND_INTERFACE=3,
    TKIND_RECORD=1,
    TKIND_COCLASS=5,
    TKIND_DISPATCH=4,
    TKIND_MODULE=2,
    TKIND_UNION=7,
    TKIND_ENUM=0
} tagTYPEKIND;

typedef enum tagTYPEKIND TYPEKIND;

typedef struct ITypeCompVtbl ITypeCompVtbl, *PITypeCompVtbl;

typedef enum tagDESCKIND {
    DESCKIND_FUNCDESC=1,
    DESCKIND_VARDESC=2,
    DESCKIND_IMPLICITAPPOBJ=4,
    DESCKIND_MAX=5,
    DESCKIND_NONE=0,
    DESCKIND_TYPECOMP=3
} tagDESCKIND;

typedef enum tagDESCKIND DESCKIND;

typedef union tagBINDPTR tagBINDPTR, *PtagBINDPTR;

typedef union tagBINDPTR BINDPTR;

typedef union _union_2711 _union_2711, *P_union_2711;

typedef enum tagVARKIND {
    VAR_CONST=2,
    VAR_DISPATCH=3,
    VAR_STATIC=1,
    VAR_PERINSTANCE=0
} tagVARKIND;

typedef enum tagVARKIND VARKIND;

typedef struct ITypeLibVtbl ITypeLibVtbl, *PITypeLibVtbl;

typedef struct tagTLIBATTR tagTLIBATTR, *PtagTLIBATTR;

typedef struct tagTLIBATTR TLIBATTR;

typedef enum tagSYSKIND {
    SYS_WIN16=0,
    SYS_WIN64=3,
    SYS_MAC=2,
    SYS_WIN32=1
} tagSYSKIND;

typedef enum tagSYSKIND SYSKIND;

struct _struct_1693 {
    ulong Lo;
    long Hi;
};

union tagCY {
    struct _struct_1693 s;
    LONGLONG int64;
};

struct _struct_1698 {
    ULONG Lo32;
    ULONG Mid32;
};

union _union_1697 {
    struct _struct_1698 s2;
    ULONGLONG Lo64;
};

struct _struct_1696 {
    BYTE scale;
    BYTE sign;
};

union _union_1695 {
    struct _struct_1696 s;
    USHORT signscale;
};

struct tagDEC {
    USHORT wReserved;
    union _union_1695 u;
    ULONG Hi32;
    union _union_1697 u2;
};

struct __tagBRECORD {
    PVOID pvRecord;
    struct IRecordInfo * pRecInfo;
};

union _union_2685 {
    LONGLONG llVal;
    LONG lVal;
    BYTE bVal;
    SHORT iVal;
    FLOAT fltVal;
    DOUBLE dblVal;
    VARIANT_BOOL boolVal;
    SCODE scode;
    CY cyVal;
    DATE date;
    BSTR bstrVal;
    struct IUnknown * punkVal;
    struct IDispatch * pdispVal;
    SAFEARRAY * parray;
    BYTE * pbVal;
    SHORT * piVal;
    LONG * plVal;
    LONGLONG * pllVal;
    FLOAT * pfltVal;
    DOUBLE * pdblVal;
    VARIANT_BOOL * pboolVal;
    SCODE * pscode;
    CY * pcyVal;
    DATE * pdate;
    BSTR * pbstrVal;
    struct IUnknown * * ppunkVal;
    struct IDispatch * * ppdispVal;
    SAFEARRAY * * pparray;
    VARIANT * pvarVal;
    PVOID byref;
    CHAR cVal;
    USHORT uiVal;
    ULONG ulVal;
    ULONGLONG ullVal;
    INT intVal;
    UINT uintVal;
    DECIMAL * pdecVal;
    CHAR * pcVal;
    USHORT * puiVal;
    ULONG * pulVal;
    ULONGLONG * pullVal;
    INT * pintVal;
    UINT * puintVal;
    struct __tagBRECORD brecVal;
};

struct __tagVARIANT {
    VARTYPE vt;
    WORD wReserved1;
    WORD wReserved2;
    WORD wReserved3;
    union _union_2685 n3;
};

union _union_2683 {
    struct __tagVARIANT n2;
    DECIMAL decVal;
};

union _union_2691 {
    struct tagTYPEDESC * lptdesc;
    struct tagARRAYDESC * lpadesc;
    HREFTYPE hreftype;
};

struct tagTYPEDESC {
    union _union_2691 u;
    VARTYPE vt;
};

struct tagIDLDESC {
    ULONG_PTR dwReserved;
    USHORT wIDLFlags;
};

struct tagPARAMDESC {
    LPPARAMDESCEX pparamdescex;
    USHORT wParamFlags;
};

union _union_2702 {
    IDLDESC idldesc;
    PARAMDESC paramdesc;
};

struct tagELEMDESC {
    TYPEDESC tdesc;
    union _union_2702 u;
};

struct tagFUNCDESC {
    MEMBERID memid;
    SCODE * lprgscode;
    ELEMDESC * lprgelemdescParam;
    FUNCKIND funckind;
    INVOKEKIND invkind;
    CALLCONV callconv;
    SHORT cParams;
    SHORT cParamsOpt;
    SHORT oVft;
    SHORT cScodes;
    ELEMDESC elemdescFunc;
    WORD wFuncFlags;
};

struct tagVARIANT {
    union _union_2683 n1;
};

struct tagPARAMDESCEX {
    ULONG cBytes;
    VARIANTARG varDefaultValue;
};

union _union_2711 {
    ULONG oInst;
    VARIANT * lpvarValue;
};

struct tagVARDESC {
    MEMBERID memid;
    LPOLESTR lpstrSchema;
    union _union_2711 u;
    ELEMDESC elemdescVar;
    WORD wVarFlags;
    VARKIND varkind;
};

struct ITypeCompVtbl {
    HRESULT (* QueryInterface)(struct ITypeComp *, IID *, void * *);
    ULONG (* AddRef)(struct ITypeComp *);
    ULONG (* Release)(struct ITypeComp *);
    HRESULT (* Bind)(struct ITypeComp *, LPOLESTR, ULONG, WORD, struct ITypeInfo * *, DESCKIND *, BINDPTR *);
    HRESULT (* BindType)(struct ITypeComp *, LPOLESTR, ULONG, struct ITypeInfo * *, struct ITypeComp * *);
};

struct tagSAFEARRAYBOUND {
    ULONG cElements;
    LONG lLbound;
};

struct tagSAFEARRAY {
    USHORT cDims;
    USHORT fFeatures;
    ULONG cbElements;
    ULONG cLocks;
    PVOID pvData;
    SAFEARRAYBOUND rgsabound[1];
};

struct ITypeInfoVtbl {
    HRESULT (* QueryInterface)(struct ITypeInfo *, IID *, void * *);
    ULONG (* AddRef)(struct ITypeInfo *);
    ULONG (* Release)(struct ITypeInfo *);
    HRESULT (* GetTypeAttr)(struct ITypeInfo *, TYPEATTR * *);
    HRESULT (* GetTypeComp)(struct ITypeInfo *, struct ITypeComp * *);
    HRESULT (* GetFuncDesc)(struct ITypeInfo *, UINT, FUNCDESC * *);
    HRESULT (* GetVarDesc)(struct ITypeInfo *, UINT, VARDESC * *);
    HRESULT (* GetNames)(struct ITypeInfo *, MEMBERID, BSTR *, UINT, UINT *);
    HRESULT (* GetRefTypeOfImplType)(struct ITypeInfo *, UINT, HREFTYPE *);
    HRESULT (* GetImplTypeFlags)(struct ITypeInfo *, UINT, INT *);
    HRESULT (* GetIDsOfNames)(struct ITypeInfo *, LPOLESTR *, UINT, MEMBERID *);
    HRESULT (* Invoke)(struct ITypeInfo *, PVOID, MEMBERID, WORD, DISPPARAMS *, VARIANT *, EXCEPINFO *, UINT *);
    HRESULT (* GetDocumentation)(struct ITypeInfo *, MEMBERID, BSTR *, BSTR *, DWORD *, BSTR *);
    HRESULT (* GetDllEntry)(struct ITypeInfo *, MEMBERID, INVOKEKIND, BSTR *, BSTR *, WORD *);
    HRESULT (* GetRefTypeInfo)(struct ITypeInfo *, HREFTYPE, struct ITypeInfo * *);
    HRESULT (* AddressOfMember)(struct ITypeInfo *, MEMBERID, INVOKEKIND, PVOID *);
    HRESULT (* CreateInstance)(struct ITypeInfo *, struct IUnknown *, IID *, PVOID *);
    HRESULT (* GetMops)(struct ITypeInfo *, MEMBERID, BSTR *);
    HRESULT (* GetContainingTypeLib)(struct ITypeInfo *, struct ITypeLib * *, UINT *);
    void (* ReleaseTypeAttr)(struct ITypeInfo *, TYPEATTR *);
    void (* ReleaseFuncDesc)(struct ITypeInfo *, FUNCDESC *);
    void (* ReleaseVarDesc)(struct ITypeInfo *, VARDESC *);
};

struct ITypeLibVtbl {
    HRESULT (* QueryInterface)(struct ITypeLib *, IID *, void * *);
    ULONG (* AddRef)(struct ITypeLib *);
    ULONG (* Release)(struct ITypeLib *);
    UINT (* GetTypeInfoCount)(struct ITypeLib *);
    HRESULT (* GetTypeInfo)(struct ITypeLib *, UINT, struct ITypeInfo * *);
    HRESULT (* GetTypeInfoType)(struct ITypeLib *, UINT, TYPEKIND *);
    HRESULT (* GetTypeInfoOfGuid)(struct ITypeLib *, GUID *, struct ITypeInfo * *);
    HRESULT (* GetLibAttr)(struct ITypeLib *, TLIBATTR * *);
    HRESULT (* GetTypeComp)(struct ITypeLib *, struct ITypeComp * *);
    HRESULT (* GetDocumentation)(struct ITypeLib *, INT, BSTR *, BSTR *, DWORD *, BSTR *);
    HRESULT (* IsName)(struct ITypeLib *, LPOLESTR, ULONG, BOOL *);
    HRESULT (* FindName)(struct ITypeLib *, LPOLESTR, ULONG, struct ITypeInfo * *, MEMBERID *, USHORT *);
    void (* ReleaseTLibAttr)(struct ITypeLib *, TLIBATTR *);
};

struct tagTLIBATTR {
    GUID guid;
    LCID lcid;
    SYSKIND syskind;
    WORD wMajorVerNum;
    WORD wMinorVerNum;
    WORD wLibFlags;
};

struct tagARRAYDESC {
    TYPEDESC tdescElem;
    USHORT cDims;
    SAFEARRAYBOUND rgbounds[1];
};

struct ITypeComp {
    struct ITypeCompVtbl * lpVtbl;
};

struct IRecordInfo {
    struct IRecordInfoVtbl * lpVtbl;
};

struct tagTYPEATTR {
    GUID guid;
    LCID lcid;
    DWORD dwReserved;
    MEMBERID memidConstructor;
    MEMBERID memidDestructor;
    LPOLESTR lpstrSchema;
    ULONG cbSizeInstance;
    TYPEKIND typekind;
    WORD cFuncs;
    WORD cVars;
    WORD cImplTypes;
    WORD cbSizeVft;
    WORD cbAlignment;
    WORD wTypeFlags;
    WORD wMajorVerNum;
    WORD wMinorVerNum;
    TYPEDESC tdescAlias;
    IDLDESC idldescType;
};

struct IRecordInfoVtbl {
    HRESULT (* QueryInterface)(struct IRecordInfo *, IID *, void * *);
    ULONG (* AddRef)(struct IRecordInfo *);
    ULONG (* Release)(struct IRecordInfo *);
    HRESULT (* RecordInit)(struct IRecordInfo *, PVOID);
    HRESULT (* RecordClear)(struct IRecordInfo *, PVOID);
    HRESULT (* RecordCopy)(struct IRecordInfo *, PVOID, PVOID);
    HRESULT (* GetGuid)(struct IRecordInfo *, GUID *);
    HRESULT (* GetName)(struct IRecordInfo *, BSTR *);
    HRESULT (* GetSize)(struct IRecordInfo *, ULONG *);
    HRESULT (* GetTypeInfo)(struct IRecordInfo *, struct ITypeInfo * *);
    HRESULT (* GetField)(struct IRecordInfo *, PVOID, LPCOLESTR, VARIANT *);
    HRESULT (* GetFieldNoCopy)(struct IRecordInfo *, PVOID, LPCOLESTR, VARIANT *, PVOID *);
    HRESULT (* PutField)(struct IRecordInfo *, ULONG, PVOID, LPCOLESTR, VARIANT *);
    HRESULT (* PutFieldNoCopy)(struct IRecordInfo *, ULONG, PVOID, LPCOLESTR, VARIANT *);
    HRESULT (* GetFieldNames)(struct IRecordInfo *, ULONG *, BSTR *);
    BOOL (* IsMatchingType)(struct IRecordInfo *, struct IRecordInfo *);
    PVOID (* RecordCreate)(struct IRecordInfo *);
    HRESULT (* RecordCreateCopy)(struct IRecordInfo *, PVOID, PVOID *);
    HRESULT (* RecordDestroy)(struct IRecordInfo *, PVOID);
};

struct tagDISPPARAMS {
    VARIANTARG * rgvarg;
    DISPID * rgdispidNamedArgs;
    UINT cArgs;
    UINT cNamedArgs;
};

union tagBINDPTR {
    FUNCDESC * lpfuncdesc;
    VARDESC * lpvardesc;
    struct ITypeComp * lptcomp;
};

struct IDispatch {
    struct IDispatchVtbl * lpVtbl;
};

struct IUnknownVtbl {
    HRESULT (* QueryInterface)(struct IUnknown *, IID *, void * *);
    ULONG (* AddRef)(struct IUnknown *);
    ULONG (* Release)(struct IUnknown *);
};

struct IDispatchVtbl {
    HRESULT (* QueryInterface)(struct IDispatch *, IID *, void * *);
    ULONG (* AddRef)(struct IDispatch *);
    ULONG (* Release)(struct IDispatch *);
    HRESULT (* GetTypeInfoCount)(struct IDispatch *, UINT *);
    HRESULT (* GetTypeInfo)(struct IDispatch *, UINT, LCID, struct ITypeInfo * *);
    HRESULT (* GetIDsOfNames)(struct IDispatch *, IID *, LPOLESTR *, UINT, LCID, DISPID *);
    HRESULT (* Invoke)(struct IDispatch *, DISPID, IID *, LCID, WORD, DISPPARAMS *, VARIANT *, EXCEPINFO *, UINT *);
};

struct IUnknown {
    struct IUnknownVtbl * lpVtbl;
};

struct ITypeLib {
    struct ITypeLibVtbl * lpVtbl;
};

struct ITypeInfo {
    struct ITypeInfoVtbl * lpVtbl;
};

struct tagEXCEPINFO {
    WORD wCode;
    WORD wReserved;
    BSTR bstrSource;
    BSTR bstrDescription;
    BSTR bstrHelpFile;
    DWORD dwHelpContext;
    PVOID pvReserved;
    HRESULT (* pfnDeferredFillIn)(struct tagEXCEPINFO *);
    SCODE scode;
};

typedef struct IAdviseSink IAdviseSink, *PIAdviseSink;

typedef struct IAdviseSinkVtbl IAdviseSinkVtbl, *PIAdviseSinkVtbl;

typedef struct tagFORMATETC tagFORMATETC, *PtagFORMATETC;

typedef struct tagFORMATETC FORMATETC;

typedef struct tagSTGMEDIUM tagSTGMEDIUM, *PtagSTGMEDIUM;

typedef struct tagSTGMEDIUM uSTGMEDIUM;

typedef uSTGMEDIUM STGMEDIUM;

typedef struct IMoniker IMoniker, *PIMoniker;

typedef WORD CLIPFORMAT;

typedef struct tagDVTARGETDEVICE tagDVTARGETDEVICE, *PtagDVTARGETDEVICE;

typedef struct tagDVTARGETDEVICE DVTARGETDEVICE;

typedef union _union_2260 _union_2260, *P_union_2260;

typedef struct IMonikerVtbl IMonikerVtbl, *PIMonikerVtbl;

typedef struct IStream IStream, *PIStream;

typedef struct IBindCtx IBindCtx, *PIBindCtx;

typedef struct IEnumMoniker IEnumMoniker, *PIEnumMoniker;

typedef void * HMETAFILEPICT;

typedef struct HENHMETAFILE__ HENHMETAFILE__, *PHENHMETAFILE__;

typedef struct HENHMETAFILE__ * HENHMETAFILE;

typedef HANDLE HGLOBAL;

typedef struct IStorage IStorage, *PIStorage;

typedef struct IStreamVtbl IStreamVtbl, *PIStreamVtbl;

typedef struct tagSTATSTG tagSTATSTG, *PtagSTATSTG;

typedef struct tagSTATSTG STATSTG;

typedef struct IBindCtxVtbl IBindCtxVtbl, *PIBindCtxVtbl;

typedef struct tagBIND_OPTS tagBIND_OPTS, *PtagBIND_OPTS;

typedef struct tagBIND_OPTS BIND_OPTS;

typedef struct IRunningObjectTable IRunningObjectTable, *PIRunningObjectTable;

typedef struct IEnumString IEnumString, *PIEnumString;

typedef struct IEnumMonikerVtbl IEnumMonikerVtbl, *PIEnumMonikerVtbl;

typedef struct IStorageVtbl IStorageVtbl, *PIStorageVtbl;

typedef LPOLESTR * SNB;

typedef struct IEnumSTATSTG IEnumSTATSTG, *PIEnumSTATSTG;

typedef struct IRunningObjectTableVtbl IRunningObjectTableVtbl, *PIRunningObjectTableVtbl;

typedef struct IEnumStringVtbl IEnumStringVtbl, *PIEnumStringVtbl;

typedef struct IEnumSTATSTGVtbl IEnumSTATSTGVtbl, *PIEnumSTATSTGVtbl;

struct IAdviseSink {
    struct IAdviseSinkVtbl * lpVtbl;
};

struct IAdviseSinkVtbl {
    HRESULT (* QueryInterface)(struct IAdviseSink *, IID *, void * *);
    ULONG (* AddRef)(struct IAdviseSink *);
    ULONG (* Release)(struct IAdviseSink *);
    void (* OnDataChange)(struct IAdviseSink *, FORMATETC *, STGMEDIUM *);
    void (* OnViewChange)(struct IAdviseSink *, DWORD, LONG);
    void (* OnRename)(struct IAdviseSink *, struct IMoniker *);
    void (* OnSave)(struct IAdviseSink *);
    void (* OnClose)(struct IAdviseSink *);
};

struct IStreamVtbl {
    HRESULT (* QueryInterface)(struct IStream *, IID *, void * *);
    ULONG (* AddRef)(struct IStream *);
    ULONG (* Release)(struct IStream *);
    HRESULT (* Read)(struct IStream *, void *, ULONG, ULONG *);
    HRESULT (* Write)(struct IStream *, void *, ULONG, ULONG *);
    HRESULT (* Seek)(struct IStream *, LARGE_INTEGER, DWORD, ULARGE_INTEGER *);
    HRESULT (* SetSize)(struct IStream *, ULARGE_INTEGER);
    HRESULT (* CopyTo)(struct IStream *, struct IStream *, ULARGE_INTEGER, ULARGE_INTEGER *, ULARGE_INTEGER *);
    HRESULT (* Commit)(struct IStream *, DWORD);
    HRESULT (* Revert)(struct IStream *);
    HRESULT (* LockRegion)(struct IStream *, ULARGE_INTEGER, ULARGE_INTEGER, DWORD);
    HRESULT (* UnlockRegion)(struct IStream *, ULARGE_INTEGER, ULARGE_INTEGER, DWORD);
    HRESULT (* Stat)(struct IStream *, STATSTG *, DWORD);
    HRESULT (* Clone)(struct IStream *, struct IStream * *);
};

union _union_2260 {
    HBITMAP hBitmap;
    HMETAFILEPICT hMetaFilePict;
    HENHMETAFILE hEnhMetaFile;
    HGLOBAL hGlobal;
    LPOLESTR lpszFileName;
    struct IStream * pstm;
    struct IStorage * pstg;
};

struct tagFORMATETC {
    CLIPFORMAT cfFormat;
    DVTARGETDEVICE * ptd;
    DWORD dwAspect;
    LONG lindex;
    DWORD tymed;
};

struct IEnumStringVtbl {
    HRESULT (* QueryInterface)(struct IEnumString *, IID *, void * *);
    ULONG (* AddRef)(struct IEnumString *);
    ULONG (* Release)(struct IEnumString *);
    HRESULT (* Next)(struct IEnumString *, ULONG, LPOLESTR *, ULONG *);
    HRESULT (* Skip)(struct IEnumString *, ULONG);
    HRESULT (* Reset)(struct IEnumString *);
    HRESULT (* Clone)(struct IEnumString *, struct IEnumString * *);
};

struct IStream {
    struct IStreamVtbl * lpVtbl;
};

struct IMoniker {
    struct IMonikerVtbl * lpVtbl;
};

struct IEnumString {
    struct IEnumStringVtbl * lpVtbl;
};

struct IEnumMonikerVtbl {
    HRESULT (* QueryInterface)(struct IEnumMoniker *, IID *, void * *);
    ULONG (* AddRef)(struct IEnumMoniker *);
    ULONG (* Release)(struct IEnumMoniker *);
    HRESULT (* Next)(struct IEnumMoniker *, ULONG, struct IMoniker * *, ULONG *);
    HRESULT (* Skip)(struct IEnumMoniker *, ULONG);
    HRESULT (* Reset)(struct IEnumMoniker *);
    HRESULT (* Clone)(struct IEnumMoniker *, struct IEnumMoniker * *);
};

struct tagSTGMEDIUM {
    DWORD tymed;
    union _union_2260 u;
    struct IUnknown * pUnkForRelease;
};

struct tagBIND_OPTS {
    DWORD cbStruct;
    DWORD grfFlags;
    DWORD grfMode;
    DWORD dwTickCountDeadline;
};

struct tagDVTARGETDEVICE {
    DWORD tdSize;
    WORD tdDriverNameOffset;
    WORD tdDeviceNameOffset;
    WORD tdPortNameOffset;
    WORD tdExtDevmodeOffset;
    BYTE tdData[1];
};

struct IBindCtx {
    struct IBindCtxVtbl * lpVtbl;
};

struct IBindCtxVtbl {
    HRESULT (* QueryInterface)(struct IBindCtx *, IID *, void * *);
    ULONG (* AddRef)(struct IBindCtx *);
    ULONG (* Release)(struct IBindCtx *);
    HRESULT (* RegisterObjectBound)(struct IBindCtx *, struct IUnknown *);
    HRESULT (* RevokeObjectBound)(struct IBindCtx *, struct IUnknown *);
    HRESULT (* ReleaseBoundObjects)(struct IBindCtx *);
    HRESULT (* SetBindOptions)(struct IBindCtx *, BIND_OPTS *);
    HRESULT (* GetBindOptions)(struct IBindCtx *, BIND_OPTS *);
    HRESULT (* GetRunningObjectTable)(struct IBindCtx *, struct IRunningObjectTable * *);
    HRESULT (* RegisterObjectParam)(struct IBindCtx *, LPOLESTR, struct IUnknown *);
    HRESULT (* GetObjectParam)(struct IBindCtx *, LPOLESTR, struct IUnknown * *);
    HRESULT (* EnumObjectParam)(struct IBindCtx *, struct IEnumString * *);
    HRESULT (* RevokeObjectParam)(struct IBindCtx *, LPOLESTR);
};

struct tagSTATSTG {
    LPOLESTR pwcsName;
    DWORD type;
    ULARGE_INTEGER cbSize;
    FILETIME mtime;
    FILETIME ctime;
    FILETIME atime;
    DWORD grfMode;
    DWORD grfLocksSupported;
    CLSID clsid;
    DWORD grfStateBits;
    DWORD reserved;
};

struct IRunningObjectTableVtbl {
    HRESULT (* QueryInterface)(struct IRunningObjectTable *, IID *, void * *);
    ULONG (* AddRef)(struct IRunningObjectTable *);
    ULONG (* Release)(struct IRunningObjectTable *);
    HRESULT (* Register)(struct IRunningObjectTable *, DWORD, struct IUnknown *, struct IMoniker *, DWORD *);
    HRESULT (* Revoke)(struct IRunningObjectTable *, DWORD);
    HRESULT (* IsRunning)(struct IRunningObjectTable *, struct IMoniker *);
    HRESULT (* GetObjectA)(struct IRunningObjectTable *, struct IMoniker *, struct IUnknown * *);
    HRESULT (* NoteChangeTime)(struct IRunningObjectTable *, DWORD, FILETIME *);
    HRESULT (* GetTimeOfLastChange)(struct IRunningObjectTable *, struct IMoniker *, FILETIME *);
    HRESULT (* EnumRunning)(struct IRunningObjectTable *, struct IEnumMoniker * *);
};

struct IStorageVtbl {
    HRESULT (* QueryInterface)(struct IStorage *, IID *, void * *);
    ULONG (* AddRef)(struct IStorage *);
    ULONG (* Release)(struct IStorage *);
    HRESULT (* CreateStream)(struct IStorage *, OLECHAR *, DWORD, DWORD, DWORD, struct IStream * *);
    HRESULT (* OpenStream)(struct IStorage *, OLECHAR *, void *, DWORD, DWORD, struct IStream * *);
    HRESULT (* CreateStorage)(struct IStorage *, OLECHAR *, DWORD, DWORD, DWORD, struct IStorage * *);
    HRESULT (* OpenStorage)(struct IStorage *, OLECHAR *, struct IStorage *, DWORD, SNB, DWORD, struct IStorage * *);
    HRESULT (* CopyTo)(struct IStorage *, DWORD, IID *, SNB, struct IStorage *);
    HRESULT (* MoveElementTo)(struct IStorage *, OLECHAR *, struct IStorage *, OLECHAR *, DWORD);
    HRESULT (* Commit)(struct IStorage *, DWORD);
    HRESULT (* Revert)(struct IStorage *);
    HRESULT (* EnumElements)(struct IStorage *, DWORD, void *, DWORD, struct IEnumSTATSTG * *);
    HRESULT (* DestroyElement)(struct IStorage *, OLECHAR *);
    HRESULT (* RenameElement)(struct IStorage *, OLECHAR *, OLECHAR *);
    HRESULT (* SetElementTimes)(struct IStorage *, OLECHAR *, FILETIME *, FILETIME *, FILETIME *);
    HRESULT (* SetClass)(struct IStorage *, IID *);
    HRESULT (* SetStateBits)(struct IStorage *, DWORD, DWORD);
    HRESULT (* Stat)(struct IStorage *, STATSTG *, DWORD);
};

struct IMonikerVtbl {
    HRESULT (* QueryInterface)(struct IMoniker *, IID *, void * *);
    ULONG (* AddRef)(struct IMoniker *);
    ULONG (* Release)(struct IMoniker *);
    HRESULT (* GetClassID)(struct IMoniker *, CLSID *);
    HRESULT (* IsDirty)(struct IMoniker *);
    HRESULT (* Load)(struct IMoniker *, struct IStream *);
    HRESULT (* Save)(struct IMoniker *, struct IStream *, BOOL);
    HRESULT (* GetSizeMax)(struct IMoniker *, ULARGE_INTEGER *);
    HRESULT (* BindToObject)(struct IMoniker *, struct IBindCtx *, struct IMoniker *, IID *, void * *);
    HRESULT (* BindToStorage)(struct IMoniker *, struct IBindCtx *, struct IMoniker *, IID *, void * *);
    HRESULT (* Reduce)(struct IMoniker *, struct IBindCtx *, DWORD, struct IMoniker * *, struct IMoniker * *);
    HRESULT (* ComposeWith)(struct IMoniker *, struct IMoniker *, BOOL, struct IMoniker * *);
    HRESULT (* Enum)(struct IMoniker *, BOOL, struct IEnumMoniker * *);
    HRESULT (* IsEqual)(struct IMoniker *, struct IMoniker *);
    HRESULT (* Hash)(struct IMoniker *, DWORD *);
    HRESULT (* IsRunning)(struct IMoniker *, struct IBindCtx *, struct IMoniker *, struct IMoniker *);
    HRESULT (* GetTimeOfLastChange)(struct IMoniker *, struct IBindCtx *, struct IMoniker *, FILETIME *);
    HRESULT (* Inverse)(struct IMoniker *, struct IMoniker * *);
    HRESULT (* CommonPrefixWith)(struct IMoniker *, struct IMoniker *, struct IMoniker * *);
    HRESULT (* RelativePathTo)(struct IMoniker *, struct IMoniker *, struct IMoniker * *);
    HRESULT (* GetDisplayName)(struct IMoniker *, struct IBindCtx *, struct IMoniker *, LPOLESTR *);
    HRESULT (* ParseDisplayName)(struct IMoniker *, struct IBindCtx *, struct IMoniker *, LPOLESTR, ULONG *, struct IMoniker * *);
    HRESULT (* IsSystemMoniker)(struct IMoniker *, DWORD *);
};

struct IStorage {
    struct IStorageVtbl * lpVtbl;
};

struct IEnumSTATSTGVtbl {
    HRESULT (* QueryInterface)(struct IEnumSTATSTG *, IID *, void * *);
    ULONG (* AddRef)(struct IEnumSTATSTG *);
    ULONG (* Release)(struct IEnumSTATSTG *);
    HRESULT (* Next)(struct IEnumSTATSTG *, ULONG, STATSTG *, ULONG *);
    HRESULT (* Skip)(struct IEnumSTATSTG *, ULONG);
    HRESULT (* Reset)(struct IEnumSTATSTG *);
    HRESULT (* Clone)(struct IEnumSTATSTG *, struct IEnumSTATSTG * *);
};

struct IEnumSTATSTG {
    struct IEnumSTATSTGVtbl * lpVtbl;
};

struct IRunningObjectTable {
    struct IRunningObjectTableVtbl * lpVtbl;
};

struct HENHMETAFILE__ {
    int unused;
};

struct IEnumMoniker {
    struct IEnumMonikerVtbl * lpVtbl;
};

typedef struct IEnumSTATDATA IEnumSTATDATA, *PIEnumSTATDATA;

typedef struct IEnumSTATDATAVtbl IEnumSTATDATAVtbl, *PIEnumSTATDATAVtbl;

typedef struct tagSTATDATA tagSTATDATA, *PtagSTATDATA;

typedef struct tagSTATDATA STATDATA;

struct IEnumSTATDATA {
    struct IEnumSTATDATAVtbl * lpVtbl;
};

struct IEnumSTATDATAVtbl {
    HRESULT (* QueryInterface)(struct IEnumSTATDATA *, IID *, void * *);
    ULONG (* AddRef)(struct IEnumSTATDATA *);
    ULONG (* Release)(struct IEnumSTATDATA *);
    HRESULT (* Next)(struct IEnumSTATDATA *, ULONG, STATDATA *, ULONG *);
    HRESULT (* Skip)(struct IEnumSTATDATA *, ULONG);
    HRESULT (* Reset)(struct IEnumSTATDATA *);
    HRESULT (* Clone)(struct IEnumSTATDATA *, struct IEnumSTATDATA * *);
};

struct tagSTATDATA {
    FORMATETC formatetc;
    DWORD advf;
    struct IAdviseSink * pAdvSink;
    DWORD dwConnection;
};

typedef struct IMalloc IMalloc, *PIMalloc;

typedef struct IMallocVtbl IMallocVtbl, *PIMallocVtbl;

struct IMalloc {
    struct IMallocVtbl * lpVtbl;
};

struct IMallocVtbl {
    HRESULT (* QueryInterface)(struct IMalloc *, IID *, void * *);
    ULONG (* AddRef)(struct IMalloc *);
    ULONG (* Release)(struct IMalloc *);
    void * (* Alloc)(struct IMalloc *, SIZE_T);
    void * (* Realloc)(struct IMalloc *, void *, SIZE_T);
    void (* Free)(struct IMalloc *, void *);
    SIZE_T (* GetSize)(struct IMalloc *, void *);
    int (* DidAlloc)(struct IMalloc *, void *);
    void (* HeapMinimize)(struct IMalloc *);
};

typedef struct IEnumFORMATETCVtbl IEnumFORMATETCVtbl, *PIEnumFORMATETCVtbl;

typedef struct IEnumFORMATETC IEnumFORMATETC, *PIEnumFORMATETC;

struct IEnumFORMATETCVtbl {
    HRESULT (* QueryInterface)(struct IEnumFORMATETC *, IID *, void * *);
    ULONG (* AddRef)(struct IEnumFORMATETC *);
    ULONG (* Release)(struct IEnumFORMATETC *);
    HRESULT (* Next)(struct IEnumFORMATETC *, ULONG, FORMATETC *, ULONG *);
    HRESULT (* Skip)(struct IEnumFORMATETC *, ULONG);
    HRESULT (* Reset)(struct IEnumFORMATETC *);
    HRESULT (* Clone)(struct IEnumFORMATETC *, struct IEnumFORMATETC * *);
};

struct IEnumFORMATETC {
    struct IEnumFORMATETCVtbl * lpVtbl;
};

typedef struct IDataObjectVtbl IDataObjectVtbl, *PIDataObjectVtbl;

typedef struct IDataObject IDataObject, *PIDataObject;

struct IDataObject {
    struct IDataObjectVtbl * lpVtbl;
};

struct IDataObjectVtbl {
    HRESULT (* QueryInterface)(struct IDataObject *, IID *, void * *);
    ULONG (* AddRef)(struct IDataObject *);
    ULONG (* Release)(struct IDataObject *);
    HRESULT (* GetData)(struct IDataObject *, FORMATETC *, STGMEDIUM *);
    HRESULT (* GetDataHere)(struct IDataObject *, FORMATETC *, STGMEDIUM *);
    HRESULT (* QueryGetData)(struct IDataObject *, FORMATETC *);
    HRESULT (* GetCanonicalFormatEtc)(struct IDataObject *, FORMATETC *, FORMATETC *);
    HRESULT (* SetData)(struct IDataObject *, FORMATETC *, STGMEDIUM *, BOOL);
    HRESULT (* EnumFormatEtc)(struct IDataObject *, DWORD, struct IEnumFORMATETC * *);
    HRESULT (* DAdvise)(struct IDataObject *, FORMATETC *, DWORD, struct IAdviseSink *, DWORD *);
    HRESULT (* DUnadvise)(struct IDataObject *, DWORD);
    HRESULT (* EnumDAdvise)(struct IDataObject *, struct IEnumSTATDATA * *);
};

typedef STGMEDIUM * LPSTGMEDIUM;

typedef struct _EXCEPTION_POINTERS _EXCEPTION_POINTERS, *P_EXCEPTION_POINTERS;

struct _EXCEPTION_POINTERS {
    PEXCEPTION_RECORD ExceptionRecord;
    PCONTEXT ContextRecord;
};

typedef struct IDropTargetVtbl IDropTargetVtbl, *PIDropTargetVtbl;

typedef struct IDropTarget IDropTarget, *PIDropTarget;

typedef struct _POINTL _POINTL, *P_POINTL;

typedef struct _POINTL POINTL;

struct IDropTargetVtbl {
    HRESULT (* QueryInterface)(struct IDropTarget *, IID *, void * *);
    ULONG (* AddRef)(struct IDropTarget *);
    ULONG (* Release)(struct IDropTarget *);
    HRESULT (* DragEnter)(struct IDropTarget *, struct IDataObject *, DWORD, POINTL, DWORD *);
    HRESULT (* DragOver)(struct IDropTarget *, DWORD, POINTL, DWORD *);
    HRESULT (* DragLeave)(struct IDropTarget *);
    HRESULT (* Drop)(struct IDropTarget *, struct IDataObject *, DWORD, POINTL, DWORD *);
};

struct _POINTL {
    LONG x;
    LONG y;
};

struct IDropTarget {
    struct IDropTargetVtbl * lpVtbl;
};

typedef struct IDropTarget * LPDROPTARGET;

typedef struct _IMAGELIST _IMAGELIST, *P_IMAGELIST;

typedef struct _IMAGELIST * HIMAGELIST;

struct _IMAGELIST {
};

typedef struct HKL__ HKL__, *PHKL__;

struct HKL__ {
    int unused;
};

typedef struct tagPOINT * LPPOINT;

typedef struct HFONT__ HFONT__, *PHFONT__;

struct HFONT__ {
    int unused;
};

typedef struct HKEY__ HKEY__, *PHKEY__;

struct HKEY__ {
    int unused;
};

typedef uint * PUINT;

typedef struct HPALETTE__ HPALETTE__, *PHPALETTE__;

struct HPALETTE__ {
    int unused;
};

typedef HINSTANCE HMODULE;

typedef HANDLE HLOCAL;

typedef struct HPEN__ HPEN__, *PHPEN__;

struct HPEN__ {
    int unused;
};

typedef int (* FARPROC)(void);

typedef struct HPALETTE__ * HPALETTE;

typedef WORD ATOM;

typedef struct HRGN__ HRGN__, *PHRGN__;

typedef struct HRGN__ * HRGN;

struct HRGN__ {
    int unused;
};

typedef struct tagRECT * LPRECT;

typedef BOOL * LPBOOL;

typedef void * HGDIOBJ;

typedef struct HKEY__ * HKEY;

typedef struct HRSRC__ HRSRC__, *PHRSRC__;

typedef struct HRSRC__ * HRSRC;

struct HRSRC__ {
    int unused;
};

typedef struct HHOOK__ HHOOK__, *PHHOOK__;

struct HHOOK__ {
    int unused;
};

typedef struct HKL__ * HKL;

typedef struct HHOOK__ * HHOOK;

typedef struct HFONT__ * HFONT;

typedef DWORD * LPDWORD;

typedef struct HPEN__ * HPEN;

typedef int * LPINT;

typedef struct tagSIZE * LPSIZE;

typedef struct _FILETIME * LPFILETIME;

typedef WORD * LPWORD;

typedef HKEY * PHKEY;

typedef BYTE * PBYTE;

typedef void * LPCVOID;

typedef struct Var Var, *PVar;

struct Var {
    word wLength;
    word wValueLength;
    word wType;
};

typedef struct IMAGE_RESOURCE_DIRECTORY_ENTRY_NameStruct IMAGE_RESOURCE_DIRECTORY_ENTRY_NameStruct, *PIMAGE_RESOURCE_DIRECTORY_ENTRY_NameStruct;

struct IMAGE_RESOURCE_DIRECTORY_ENTRY_NameStruct {
    dword NameOffset;
    dword NameIsString;
};

typedef struct IMAGE_THUNK_DATA32 IMAGE_THUNK_DATA32, *PIMAGE_THUNK_DATA32;

struct IMAGE_THUNK_DATA32 {
    dword StartAddressOfRawData;
    dword EndAddressOfRawData;
    dword AddressOfIndex;
    dword AddressOfCallBacks;
    dword SizeOfZeroFill;
    dword Characteristics;
};

typedef struct IMAGE_RESOURCE_DIR_STRING_U_14 IMAGE_RESOURCE_DIR_STRING_U_14, *PIMAGE_RESOURCE_DIR_STRING_U_14;

struct IMAGE_RESOURCE_DIR_STRING_U_14 {
    word Length;
    wchar16 NameString[7];
};

typedef struct IMAGE_RESOURCE_DIR_STRING_U_16 IMAGE_RESOURCE_DIR_STRING_U_16, *PIMAGE_RESOURCE_DIR_STRING_U_16;

struct IMAGE_RESOURCE_DIR_STRING_U_16 {
    word Length;
    wchar16 NameString[8];
};

typedef struct IMAGE_RESOURCE_DIR_STRING_U_10 IMAGE_RESOURCE_DIR_STRING_U_10, *PIMAGE_RESOURCE_DIR_STRING_U_10;

struct IMAGE_RESOURCE_DIR_STRING_U_10 {
    word Length;
    wchar16 NameString[5];
};

typedef struct IMAGE_RESOURCE_DIR_STRING_U_12 IMAGE_RESOURCE_DIR_STRING_U_12, *PIMAGE_RESOURCE_DIR_STRING_U_12;

struct IMAGE_RESOURCE_DIR_STRING_U_12 {
    word Length;
    wchar16 NameString[6];
};

typedef struct StringTable StringTable, *PStringTable;

struct StringTable {
    word wLength;
    word wValueLength;
    word wType;
};

typedef struct IMAGE_SECTION_HEADER IMAGE_SECTION_HEADER, *PIMAGE_SECTION_HEADER;

typedef union Misc Misc, *PMisc;

typedef enum SectionFlags {
    IMAGE_SCN_ALIGN_2BYTES=2097152,
    IMAGE_SCN_ALIGN_128BYTES=8388608,
    IMAGE_SCN_LNK_INFO=512,
    IMAGE_SCN_ALIGN_4096BYTES=13631488,
    IMAGE_SCN_MEM_READ=1073741824,
    IMAGE_SCN_ALIGN_8BYTES=4194304,
    IMAGE_SCN_ALIGN_64BYTES=7340032,
    IMAGE_SCN_ALIGN_256BYTES=9437184,
    IMAGE_SCN_MEM_WRITE=2147483648,
    IMAGE_SCN_LNK_COMDAT=4096,
    IMAGE_SCN_MEM_16BIT=131072,
    IMAGE_SCN_ALIGN_8192BYTES=14680064,
    IMAGE_SCN_MEM_PURGEABLE=131072,
    IMAGE_SCN_GPREL=32768,
    IMAGE_SCN_MEM_EXECUTE=536870912,
    IMAGE_SCN_ALIGN_4BYTES=3145728,
    IMAGE_SCN_LNK_OTHER=256,
    IMAGE_SCN_MEM_PRELOAD=524288,
    IMAGE_SCN_ALIGN_1BYTES=1048576,
    IMAGE_SCN_MEM_NOT_PAGED=134217728,
    IMAGE_SCN_ALIGN_1024BYTES=11534336,
    IMAGE_SCN_RESERVED_0001=16,
    IMAGE_SCN_MEM_LOCKED=262144,
    IMAGE_SCN_ALIGN_512BYTES=10485760,
    IMAGE_SCN_CNT_INITIALIZED_DATA=64,
    IMAGE_SCN_ALIGN_32BYTES=6291456,
    IMAGE_SCN_MEM_DISCARDABLE=33554432,
    IMAGE_SCN_CNT_UNINITIALIZED_DATA=128,
    IMAGE_SCN_ALIGN_2048BYTES=12582912,
    IMAGE_SCN_MEM_SHARED=268435456,
    IMAGE_SCN_CNT_CODE=32,
    IMAGE_SCN_LNK_REMOVE=2048,
    IMAGE_SCN_ALIGN_16BYTES=5242880,
    IMAGE_SCN_TYPE_NO_PAD=8,
    IMAGE_SCN_LNK_NRELOC_OVFL=16777216,
    IMAGE_SCN_RESERVED_0040=1024,
    IMAGE_SCN_MEM_NOT_CACHED=67108864
} SectionFlags;

union Misc {
    dword PhysicalAddress;
    dword VirtualSize;
};

struct IMAGE_SECTION_HEADER {
    char Name[8];
    union Misc Misc;
    ImageBaseOffset32 VirtualAddress;
    dword SizeOfRawData;
    dword PointerToRawData;
    dword PointerToRelocations;
    dword PointerToLinenumbers;
    word NumberOfRelocations;
    word NumberOfLinenumbers;
    enum SectionFlags Characteristics;
};

typedef struct IMAGE_RESOURCE_DIR_STRING_U_8 IMAGE_RESOURCE_DIR_STRING_U_8, *PIMAGE_RESOURCE_DIR_STRING_U_8;

struct IMAGE_RESOURCE_DIR_STRING_U_8 {
    word Length;
    wchar16 NameString[4];
};

typedef struct IMAGE_DATA_DIRECTORY IMAGE_DATA_DIRECTORY, *PIMAGE_DATA_DIRECTORY;

struct IMAGE_DATA_DIRECTORY {
    ImageBaseOffset32 VirtualAddress;
    dword Size;
};

typedef struct IMAGE_RESOURCE_DATA_ENTRY IMAGE_RESOURCE_DATA_ENTRY, *PIMAGE_RESOURCE_DATA_ENTRY;

struct IMAGE_RESOURCE_DATA_ENTRY {
    dword OffsetToData;
    dword Size;
    dword CodePage;
    dword Reserved;
};

typedef struct IMAGE_RESOURCE_DIRECTORY IMAGE_RESOURCE_DIRECTORY, *PIMAGE_RESOURCE_DIRECTORY;

struct IMAGE_RESOURCE_DIRECTORY {
    dword Characteristics;
    dword TimeDateStamp;
    word MajorVersion;
    word MinorVersion;
    word NumberOfNamedEntries;
    word NumberOfIdEntries;
};

typedef union IMAGE_RESOURCE_DIRECTORY_ENTRY_NameUnion IMAGE_RESOURCE_DIRECTORY_ENTRY_NameUnion, *PIMAGE_RESOURCE_DIRECTORY_ENTRY_NameUnion;

union IMAGE_RESOURCE_DIRECTORY_ENTRY_NameUnion {
    struct IMAGE_RESOURCE_DIRECTORY_ENTRY_NameStruct IMAGE_RESOURCE_DIRECTORY_ENTRY_NameStruct;
    dword Name;
    word Id;
};

typedef struct IMAGE_OPTIONAL_HEADER32 IMAGE_OPTIONAL_HEADER32, *PIMAGE_OPTIONAL_HEADER32;

struct IMAGE_OPTIONAL_HEADER32 {
    word Magic;
    byte MajorLinkerVersion;
    byte MinorLinkerVersion;
    dword SizeOfCode;
    dword SizeOfInitializedData;
    dword SizeOfUninitializedData;
    ImageBaseOffset32 AddressOfEntryPoint;
    ImageBaseOffset32 BaseOfCode;
    ImageBaseOffset32 BaseOfData;
    pointer32 ImageBase;
    dword SectionAlignment;
    dword FileAlignment;
    word MajorOperatingSystemVersion;
    word MinorOperatingSystemVersion;
    word MajorImageVersion;
    word MinorImageVersion;
    word MajorSubsystemVersion;
    word MinorSubsystemVersion;
    dword Win32VersionValue;
    dword SizeOfImage;
    dword SizeOfHeaders;
    dword CheckSum;
    word Subsystem;
    word DllCharacteristics;
    dword SizeOfStackReserve;
    dword SizeOfStackCommit;
    dword SizeOfHeapReserve;
    dword SizeOfHeapCommit;
    dword LoaderFlags;
    dword NumberOfRvaAndSizes;
    struct IMAGE_DATA_DIRECTORY DataDirectory[16];
};

typedef struct IMAGE_FILE_HEADER IMAGE_FILE_HEADER, *PIMAGE_FILE_HEADER;

struct IMAGE_FILE_HEADER {
    word Machine; // 332
    word NumberOfSections;
    dword TimeDateStamp;
    dword PointerToSymbolTable;
    dword NumberOfSymbols;
    word SizeOfOptionalHeader;
    word Characteristics;
};

typedef struct IMAGE_RESOURCE_DIR_STRING_U_36 IMAGE_RESOURCE_DIR_STRING_U_36, *PIMAGE_RESOURCE_DIR_STRING_U_36;

struct IMAGE_RESOURCE_DIR_STRING_U_36 {
    word Length;
    wchar16 NameString[18];
};

typedef struct IMAGE_NT_HEADERS32 IMAGE_NT_HEADERS32, *PIMAGE_NT_HEADERS32;

struct IMAGE_NT_HEADERS32 {
    char Signature[4];
    struct IMAGE_FILE_HEADER FileHeader;
    struct IMAGE_OPTIONAL_HEADER32 OptionalHeader;
};

typedef struct StringFileInfo StringFileInfo, *PStringFileInfo;

struct StringFileInfo {
    word wLength;
    word wValueLength;
    word wType;
};

typedef union IMAGE_RESOURCE_DIRECTORY_ENTRY IMAGE_RESOURCE_DIRECTORY_ENTRY, *PIMAGE_RESOURCE_DIRECTORY_ENTRY;

union IMAGE_RESOURCE_DIRECTORY_ENTRY {
    union IMAGE_RESOURCE_DIRECTORY_ENTRY_NameUnion NameUnion;
    union IMAGE_RESOURCE_DIRECTORY_ENTRY_DirectoryUnion DirectoryUnion;
};

typedef struct IMAGE_RESOURCE_DIR_STRING_U_18 IMAGE_RESOURCE_DIR_STRING_U_18, *PIMAGE_RESOURCE_DIR_STRING_U_18;

struct IMAGE_RESOURCE_DIR_STRING_U_18 {
    word Length;
    wchar16 NameString[9];
};

typedef struct VS_VERSION_INFO VS_VERSION_INFO, *PVS_VERSION_INFO;

struct VS_VERSION_INFO {
    word StructLength;
    word ValueLength;
    word StructType;
    wchar16 Info[16];
    byte Padding[2];
    dword Signature;
    word StructVersion[2];
    word FileVersion[4];
    word ProductVersion[4];
    dword FileFlagsMask[2];
    dword FileFlags;
    dword FileOS;
    dword FileType;
    dword FileSubtype;
    dword FileTimestamp;
};

typedef struct VarFileInfo VarFileInfo, *PVarFileInfo;

struct VarFileInfo {
    word wLength;
    word wValueLength;
    word wType;
};

typedef struct IMAGE_RESOURCE_DIR_STRING_U_20 IMAGE_RESOURCE_DIR_STRING_U_20, *PIMAGE_RESOURCE_DIR_STRING_U_20;

struct IMAGE_RESOURCE_DIR_STRING_U_20 {
    word Length;
    wchar16 NameString[10];
};

typedef struct StringInfo StringInfo, *PStringInfo;

struct StringInfo {
    word wLength;
    word wValueLength;
    word wType;
};

typedef struct IMAGE_RESOURCE_DIR_STRING_U_26 IMAGE_RESOURCE_DIR_STRING_U_26, *PIMAGE_RESOURCE_DIR_STRING_U_26;

struct IMAGE_RESOURCE_DIR_STRING_U_26 {
    word Length;
    wchar16 NameString[13];
};

typedef struct IMAGE_RESOURCE_DIR_STRING_U_28 IMAGE_RESOURCE_DIR_STRING_U_28, *PIMAGE_RESOURCE_DIR_STRING_U_28;

struct IMAGE_RESOURCE_DIR_STRING_U_28 {
    word Length;
    wchar16 NameString[14];
};

typedef struct IMAGE_RESOURCE_DIR_STRING_U_22 IMAGE_RESOURCE_DIR_STRING_U_22, *PIMAGE_RESOURCE_DIR_STRING_U_22;

struct IMAGE_RESOURCE_DIR_STRING_U_22 {
    word Length;
    wchar16 NameString[11];
};

typedef struct IMAGE_RESOURCE_DIR_STRING_U_24 IMAGE_RESOURCE_DIR_STRING_U_24, *PIMAGE_RESOURCE_DIR_STRING_U_24;

struct IMAGE_RESOURCE_DIR_STRING_U_24 {
    word Length;
    wchar16 NameString[12];
};

typedef LONG LSTATUS;

typedef ACCESS_MASK REGSAM;

typedef struct tagMIDIOUTCAPSA tagMIDIOUTCAPSA, *PtagMIDIOUTCAPSA;

typedef UINT MMVERSION;

struct tagMIDIOUTCAPSA {
    WORD wMid;
    WORD wPid;
    MMVERSION vDriverVersion;
    CHAR szPname[32];
    WORD wTechnology;
    WORD wVoices;
    WORD wNotes;
    WORD wChannelMask;
    DWORD dwSupport;
};

typedef struct tagMIDIINCAPSA tagMIDIINCAPSA, *PtagMIDIINCAPSA;

typedef struct tagMIDIINCAPSA * LPMIDIINCAPSA;

struct tagMIDIINCAPSA {
    WORD wMid;
    WORD wPid;
    MMVERSION vDriverVersion;
    CHAR szPname[32];
    DWORD dwSupport;
};

typedef struct HMIDIOUT__ HMIDIOUT__, *PHMIDIOUT__;

typedef struct HMIDIOUT__ * HMIDIOUT;

struct HMIDIOUT__ {
    int unused;
};

typedef struct HMIDIIN__ HMIDIIN__, *PHMIDIIN__;

typedef struct HMIDIIN__ * HMIDIIN;

struct HMIDIIN__ {
    int unused;
};

typedef UINT MMRESULT;

typedef struct midihdr_tag midihdr_tag, *Pmidihdr_tag;

struct midihdr_tag {
    LPSTR lpData;
    DWORD dwBufferLength;
    DWORD dwBytesRecorded;
    DWORD_PTR dwUser;
    DWORD dwFlags;
    struct midihdr_tag * lpNext;
    DWORD_PTR reserved;
    DWORD dwOffset;
    DWORD_PTR dwReserved[8];
};

typedef struct midihdr_tag * LPMIDIHDR;

typedef HMIDIIN * LPHMIDIIN;

typedef struct tagMIDIOUTCAPSA * LPMIDIOUTCAPSA;

typedef HMIDIOUT * LPHMIDIOUT;

typedef char * va_list;

typedef struct tagOFNA tagOFNA, *PtagOFNA;

typedef struct tagOFNA * LPOPENFILENAMEA;

typedef UINT_PTR (* LPOFNHOOKPROC)(HWND, UINT, WPARAM, LPARAM);

struct tagOFNA {
    DWORD lStructSize;
    HWND hwndOwner;
    HINSTANCE hInstance;
    LPCSTR lpstrFilter;
    LPSTR lpstrCustomFilter;
    DWORD nMaxCustFilter;
    DWORD nFilterIndex;
    LPSTR lpstrFile;
    DWORD nMaxFile;
    LPSTR lpstrFileTitle;
    DWORD nMaxFileTitle;
    LPCSTR lpstrInitialDir;
    LPCSTR lpstrTitle;
    DWORD Flags;
    WORD nFileOffset;
    WORD nFileExtension;
    LPCSTR lpstrDefExt;
    LPARAM lCustData;
    LPOFNHOOKPROC lpfnHook;
    LPCSTR lpTemplateName;
    void * pvReserved;
    DWORD dwReserved;
    DWORD FlagsEx;
};




BOOL __stdcall CloseHandle(HANDLE hObject);
HANDLE __stdcall CreateFileA(LPCSTR lpFileName,DWORD dwDesiredAccess,DWORD dwShareMode,LPSECURITY_ATTRIBUTES lpSecurityAttributes,DWORD dwCreationDisposition,DWORD dwFlagsAndAttributes,HANDLE hTemplateFile);
DWORD __stdcall GetFileType(HANDLE hFile);
DWORD __stdcall GetFileSize(HANDLE hFile,LPDWORD lpFileSizeHigh);
HANDLE __stdcall GetStdHandle(DWORD nStdHandle);
void __stdcall RaiseException(DWORD dwExceptionCode,DWORD dwExceptionFlags,DWORD nNumberOfArguments,ULONG_PTR *lpArguments);
BOOL __stdcall ReadFile(HANDLE hFile,LPVOID lpBuffer,DWORD nNumberOfBytesToRead,LPDWORD lpNumberOfBytesRead,LPOVERLAPPED lpOverlapped);
void __stdcall RtlUnwind(PVOID TargetFrame,PVOID TargetIp,PEXCEPTION_RECORD ExceptionRecord,PVOID ReturnValue);
BOOL __stdcall SetEndOfFile(HANDLE hFile);
DWORD __stdcall SetFilePointer(HANDLE hFile,LONG lDistanceToMove,PLONG lpDistanceToMoveHigh,DWORD dwMoveMethod);
LONG __stdcall UnhandledExceptionFilter(_EXCEPTION_POINTERS *ExceptionInfo);
BOOL __stdcall WriteFile(HANDLE hFile,LPCVOID lpBuffer,DWORD nNumberOfBytesToWrite,LPDWORD lpNumberOfBytesWritten,LPOVERLAPPED lpOverlapped);
LPSTR __stdcall CharNextA(LPCSTR lpsz);
HANDLE __stdcall CreateThread(LPSECURITY_ATTRIBUTES lpThreadAttributes,SIZE_T dwStackSize,LPTHREAD_START_ROUTINE lpStartAddress,LPVOID lpParameter,DWORD dwCreationFlags,LPDWORD lpThreadId);
void __stdcall ExitThread(DWORD dwExitCode);
void __stdcall ExitProcess(UINT uExitCode);
int __stdcall MessageBoxA(HWND hWnd,LPCSTR lpText,LPCSTR lpCaption,UINT uType);
BOOL __stdcall FindClose(HANDLE hFindFile);
HANDLE __stdcall FindFirstFileA(LPCSTR lpFileName,LPWIN32_FIND_DATAA lpFindFileData);
BOOL __stdcall FreeLibrary(HMODULE hLibModule);
LPSTR __stdcall GetCommandLineA(void);
DWORD __stdcall GetLastError(void);
int __stdcall GetLocaleInfoA(LCID Locale,LCTYPE LCType,LPSTR lpLCData,int cchData);
DWORD __stdcall GetModuleFileNameA(HMODULE hModule,LPSTR lpFilename,DWORD nSize);
HMODULE __stdcall GetModuleHandleA(LPCSTR lpModuleName);
FARPROC __stdcall GetProcAddress(HMODULE hModule,LPCSTR lpProcName);
void __stdcall GetStartupInfoA(LPSTARTUPINFOA lpStartupInfo);
LCID __stdcall GetThreadLocale(void);
HMODULE __stdcall LoadLibraryExA(LPCSTR lpLibFileName,HANDLE hFile,DWORD dwFlags);
int __stdcall LoadStringA(HINSTANCE hInstance,UINT uID,LPSTR lpBuffer,int cchBufferMax);
LPSTR __stdcall lstrcpyA(LPSTR lpString1,LPCSTR lpString2);
LPSTR __stdcall lstrcpynA(LPSTR lpString1,LPCSTR lpString2,int iMaxLength);
int __stdcall lstrlenA(LPCSTR lpString);
int __stdcall MultiByteToWideChar(UINT CodePage,DWORD dwFlags,LPCSTR lpMultiByteStr,int cbMultiByte,LPWSTR lpWideCharStr,int cchWideChar);
LSTATUS __stdcall RegCloseKey(HKEY hKey);
LSTATUS __stdcall RegOpenKeyExA(HKEY hKey,LPCSTR lpSubKey,DWORD ulOptions,REGSAM samDesired,PHKEY phkResult);
LSTATUS __stdcall RegQueryValueExA(HKEY hKey,LPCSTR lpValueName,LPDWORD lpReserved,LPDWORD lpType,LPBYTE lpData,LPDWORD lpcbData);
int __stdcall WideCharToMultiByte(UINT CodePage,DWORD dwFlags,LPCWSTR lpWideCharStr,int cchWideChar,LPSTR lpMultiByteStr,int cbMultiByte,LPCSTR lpDefaultChar,LPBOOL lpUsedDefaultChar);
SIZE_T __stdcall VirtualQuery(LPCVOID lpAddress,PMEMORY_BASIC_INFORMATION lpBuffer,SIZE_T dwLength);
BSTR __stdcall SysAllocStringLen(OLECHAR *strIn,UINT ui);
INT __stdcall SysReAllocStringLen(BSTR *pbstr,OLECHAR *psz,uint len);
void __stdcall SysFreeString(BSTR bstrString);
UINT __stdcall SysStringLen(BSTR param_1);
HRESULT __stdcall VariantClear(VARIANTARG *pvarg);
HRESULT __stdcall VariantCopyInd(VARIANT *pvarDest,VARIANTARG *pvargSrc);
HRESULT __stdcall VariantChangeTypeEx(VARIANTARG *pvargDest,VARIANTARG *pvarSrc,LCID lcid,USHORT wFlags,VARTYPE vt);
LONG __stdcall InterlockedDecrement(LONG *lpAddend);
WORD FUN_004013ac(void);
HLOCAL __stdcall LocalAlloc(UINT uFlags,SIZE_T uBytes);
HLOCAL __stdcall LocalFree(HLOCAL hMem);
LPVOID __stdcall VirtualAlloc(LPVOID lpAddress,SIZE_T dwSize,DWORD flAllocationType,DWORD flProtect);
BOOL __stdcall VirtualFree(LPVOID lpAddress,SIZE_T dwSize,DWORD dwFreeType);
void __stdcall InitializeCriticalSection(LPCRITICAL_SECTION lpCriticalSection);
void __stdcall EnterCriticalSection(LPCRITICAL_SECTION lpCriticalSection);
void __stdcall LeaveCriticalSection(LPCRITICAL_SECTION lpCriticalSection);
void __stdcall DeleteCriticalSection(LPCRITICAL_SECTION lpCriticalSection);
int * FUN_00401410(void);
void FUN_00401460(int param_1);
undefined4 FUN_00401468(int **param_1,int **param_2);
void FUN_00401498(int *param_1);
void FUN_004014b0(int **param_1,int **param_2,int **param_3);
undefined4 FUN_00401524(int **param_1,int **param_2);
void FUN_004015b4(int param_1,int **param_2);
void FUN_00401618(LPVOID param_1,int param_2,int **param_3);
void FUN_00401690(LPVOID param_1,int param_2,LPVOID *param_3);
void FUN_00401748(uint param_1,int param_2,LPVOID *param_3);
void FUN_004017dc(int param_1,int param_2,LPVOID *param_3);
void FUN_0040185c(int param_1,int **param_2);
void FUN_004018ec(LPVOID param_1,int param_2,LPVOID *param_3);
void FUN_00401a10(int param_1,int param_2,int **param_3);
void FUN_00401a9c(void);
void FUN_00401b60(void);
void FUN_00401c40(int *param_1);
undefined4 * FUN_00401ca4(uint param_1);
void FUN_00401cd4(uint *param_1,uint param_2);
void FUN_00401d04(int param_1,undefined4 param_2,undefined4 param_3);
void FUN_00401d28(uint *param_1,uint param_2);
uint FUN_00401d50(int param_1);
uint FUN_00401dc0(uint *param_1);
undefined4 FUN_00401df8(uint *param_1,int param_2);
void FUN_00401e90(uint **param_1,uint *param_2);
void FUN_00401f18(undefined4 param_1,undefined4 param_2,undefined4 param_3);
undefined4 FUN_00401f64(int **param_1,undefined4 param_2,undefined4 param_3);
undefined4 FUN_00401ff0(int param_1);
undefined4 FUN_0040201c(LPVOID param_1,int param_2);
int FUN_00402050(int param_1);
uint * FUN_0040207c(uint param_1);
uint * FUN_00402170(int param_1);
undefined4 FUN_004022f8(int param_1,undefined4 param_2,undefined4 param_3);
undefined4 FUN_0040249c(int param_1,int param_2,undefined4 param_3);
undefined4 FUN_0040266c(uint *param_1,uint param_2,undefined4 param_3);
void FUN_00402730(int param_1);
void FUN_00402748(int param_1);
void FUN_00402760(int *param_1,int param_2);
void FUN_004027bc(uint param_1);
void FUN_00402800(void);
void FUN_00402820(undefined4 param_1);
void FUN_00402830(byte *param_1,int param_2,int param_3);
undefined4 FUN_00402860(void);
void FUN_00402878(undefined4 *param_1,undefined4 *param_2,uint param_3);
byte * FUN_004028b8(byte *param_1,int *param_2);
void FUN_00402930(int param_1,int *param_2);
byte * FUN_00402988(byte *param_1,byte *param_2);
undefined4 FUN_004029c8(void);
undefined4 FUN_004029d4(void);
void FUN_00402a0c(undefined4 *param_1,undefined4 *param_2);
void FUN_00402a28(undefined4 *param_1,undefined4 *param_2,byte param_3);
int FUN_00402a58(byte *param_1,byte *param_2);
int * FUN_00402adc(int *param_1,int *param_2,uint param_3);
void FUN_00402b4c(undefined4 *param_1,uint param_2,undefined param_3);
void FUN_00402b6c(byte *param_1,byte **param_2);
void FUN_00402c38(char *param_1,char *param_2);
void FUN_00402c50(char *param_1,char *param_2,uint param_3);
void FUN_00402c74(uint param_1,uint param_2,undefined *param_3);
int __stdcall GetKeyboardType(int nTypeFlag);
undefined4 FUN_00402cd4(void);
void FUN_00402d04(void);
void FUN_00402dc8(void);
undefined4 FUN_00402dd4(undefined4 *param_1);
void FUN_00402dd8(int param_1,byte *param_2);
uint FUN_00402dec(byte *param_1,int param_2);
int * FUN_00402e14(int param_1);
void FUN_00402e20(int param_1);
void FUN_00402e34(int *param_1);
void FUN_00402e5c(int *param_1,char param_2,undefined4 param_3);
void FUN_00402e7c(int *param_1,char param_2);
void FUN_00402e8c(int *param_1);
void FUN_00402e98(int param_1,int *param_2);
void FUN_00402ef0(int *param_1,undefined *UNRECOVERED_JUMPTABLE,int **param_3);
void FUN_00402f20(int *param_1,int *param_2,int **param_3);
int * FUN_00402fc0(int param_1,int *param_2);
int * FUN_00403004(int *param_1,int param_2);
void FUN_0040301c(int *param_1,int param_2);
void FUN_00403038(int param_1);
void FUN_00403068(int *param_1,undefined4 param_2,undefined4 param_3);
undefined4 FUN_00403080(int *param_1,undefined4 param_2);
int * thunk_FUN_0040309c(int param_1,int param_2);
int * FUN_0040309c(int param_1,int param_2);
undefined4 FUN_004030ac(int param_1);
undefined4 FUN_004030b0(void);
void FUN_004030b8(void);
undefined4 FUN_004030ec(int param_1,byte *param_2);
void FUN_0040313c(int param_1,int param_2,byte *param_3);
int FUN_0040317c(int *param_1,byte *param_2);
void FUN_004031cc(int param_1,char param_2,undefined4 param_3,undefined4 param_4,undefined4 param_5,undefined4 param_6,undefined4 param_7);
void FUN_0040321c(int *param_1);
int * FUN_00403224(int *param_1);
int * FUN_0040322c(int *param_1,char param_2);
undefined4 FUN_00403258(undefined4 param_1,ULONG_PTR param_2);
undefined4 FUN_0040328c(undefined4 param_1);
undefined4 FUN_004032a0(undefined4 param_1);
int FUN_004032b4(int param_1,undefined4 param_2,char *param_3);
int FUN_004032d4(int param_1,undefined4 param_2,char *param_3);
undefined4 FUN_00403318(undefined4 param_1,ULONG_PTR param_2);
void FUN_00403624(undefined4 param_1);
void FUN_004036c4(undefined param_1,undefined param_2,undefined param_3,undefined4 param_4,int param_5);
void FUN_004036dc(undefined4 param_1);
void FUN_00403824(void);
void FUN_00403844(void);
void FUN_0040386c(void);
void FUN_004038cc(void);
void FUN_0040392c(undefined4 param_1,int param_2);
void FUN_0040395c(int *param_1);
void FUN_00403978(int *param_1);
void FUN_00403998(void);
bool FUN_004039e8(void);
void FUN_00403a1c(void);
void FUN_00403b3c(undefined4 param_1);
void FUN_00403b48(undefined4 param_1);
void FUN_00403b54(undefined param_1,undefined param_2,undefined param_3,code **param_4);
void FUN_00403b8c(LPSECURITY_ATTRIBUTES param_1,SIZE_T param_2,undefined4 param_3,LPDWORD param_4,DWORD param_5,undefined4 param_6);
void FUN_00403bd0(DWORD param_1);
int * FUN_00403bd8(int *param_1);
void FUN_00403bfc(int *param_1,int param_2);
void FUN_00403c2c(int *param_1,undefined4 *param_2);
void FUN_00403c70(int *param_1,int param_2);
undefined4 * FUN_00403c9c(int param_1);
void FUN_00403cc0(int *param_1,undefined4 *param_2,uint param_3);
void FUN_00403d80(int *param_1,undefined4 param_2);
void FUN_00403d90(int *param_1,undefined4 *param_2);
void FUN_00403dc0(LPSTR *param_1,LPCWSTR param_2);
void FUN_00403dfc(int *param_1,byte *param_2);
void FUN_00403e08(int *param_1,undefined4 *param_2,uint param_3);
void FUN_00403e20(LPSTR *param_1,LPCWSTR param_2);
void FUN_00403e34(undefined *param_1,undefined4 *param_2,uint param_3);
int FUN_00403e58(int param_1);
void FUN_00403e60(int *param_1,undefined4 *param_2);
void FUN_00403ea4(int *param_1,undefined4 *param_2,undefined4 *param_3);
void FUN_00403ec6(int *param_1,undefined4 *param_2,undefined4 *param_3);
void FUN_00403f18(int *param_1,int param_2);
uint * FUN_00403f68(uint *param_1,uint *param_2);
void FUN_0040400c(int param_1);
undefined * FUN_0040401c(undefined *param_1);
int FUN_00404028(int *param_1);
void FUN_00404060(int param_1,int param_2,uint param_3,int *param_4);
void FUN_004040a0(int *param_1,int param_2,int param_3);
void FUN_004040e8(undefined4 *param_1,int *param_2,int param_3);
char * FUN_00404144(char *param_1,char *param_2);
void FUN_0040418c(int *param_1,uint param_2);
void FUN_004041f8(BSTR *param_1,BSTR param_2);
BSTR * FUN_00404208(BSTR *param_1);
void FUN_00404220(BSTR *param_1,int param_2);
BSTR * FUN_00404244(BSTR *param_1,OLECHAR *param_2);
BSTR * FUN_004042ec(BSTR *param_1,OLECHAR *param_2,UINT param_3);
void FUN_00404310(BSTR *param_1,OLECHAR *param_2);
void FUN_0040434c(BSTR *param_1,LPCSTR param_2);
undefined * FUN_0040435c(undefined *param_1);
uint FUN_0040436c(uint param_1);
void FUN_00404378(UINT param_1);
void FUN_00404390(BSTR *param_1,UINT param_2);
void FUN_004043d4(int param_1,int param_2);
void FUN_00404400(undefined4 *param_1,char *param_2,int param_3);
void FUN_00404494(undefined4 *param_1,char *param_2);
int FUN_004044a0(int param_1,int param_2);
VARIANTARG * FUN_004044cc(VARIANTARG *param_1,char *param_2,int param_3);
void FUN_004045b4(VARIANTARG *param_1,char *param_2);
void FUN_004045c0(int param_1,int param_2,int param_3);
void FUN_004046dc(VARIANT *param_1,VARIANTARG *param_2,char *param_3,int param_4);
undefined4 * FUN_004047d0(int param_1,char *param_2);
void FUN_004047e4(VARIANTARG *param_1,char *param_2);
void FUN_00404810(LPCWSTR param_1,int param_2,LPSTR *param_3);
void FUN_0040489c(LPCWSTR param_1,LPSTR *param_2);
BSTR FUN_004048c0(LPCSTR param_1);
void FUN_00404944(undefined4 param_1);
void FUN_00404954(VARIANTARG *param_1);
void FUN_00404998(VARIANT *param_1,VARIANTARG *param_2);
void FUN_004049d6(undefined4 *param_1,undefined4 *param_2);
void FUN_00404a34(VARIANTARG *param_1,undefined4 *param_2,undefined4 param_3);
bool FUN_00404aa0(undefined4 param_1,undefined4 *param_2,undefined4 param_3);
void FUN_00404ab8(VARIANTARG *param_1,VARIANTARG *param_2,undefined4 param_3);
void FUN_00404b5c(VARIANTARG *param_1,int param_2);
void FUN_00404b8c(VARIANTARG *param_1,int param_2);
void FUN_00404bac(VARIANT *param_1,VARIANTARG *param_2,undefined4 param_3);
uint FUN_00404ca0(VARIANTARG *param_1);
bool FUN_00404d0c(VARIANTARG *param_1);
void FUN_00404d40(VARIANTARG *param_1);
void FUN_00404d9c(VARIANTARG *param_1);
void FUN_00404df8(int *param_1,VARIANTARG *param_2);
void FUN_00404e34(BSTR *param_1,VARIANTARG *param_2);
void FUN_00404e6c(VARIANTARG *param_1,undefined4 *param_2);
void FUN_00404eac(VARIANTARG *param_1,OLECHAR *param_2);
char * FUN_00404ee0(char *param_1,char *param_2);
void FUN_00404f10(VARIANTARG *param_1,VARIANTARG *param_2);
void FUN_00404f78(short *param_1,VARIANTARG *param_2);
void FUN_00405014(uint *param_1,uint *param_2);
VARIANTARG * FUN_00405124(VARIANTARG *param_1);
void FUN_0040512c(VARIANT *param_1);
undefined2 FUN_00405150(undefined2 *param_1);
undefined4 FUN_00405154(short *param_1);
uint FUN_00405178(uint param_1);
int FUN_00405180(int param_1);
int FUN_00405188(int param_1);
void FUN_00405190(VARIANT *param_1,VARIANTARG *param_2,char *param_3,int param_4);
VARIANTARG * thunk_FUN_004044cc(VARIANTARG *param_1,char *param_2,int param_3);
void FUN_004051a8(int *param_1,int param_2);
void FUN_004051b0(VARIANTARG **param_1,int param_2,int param_3,int *param_4);
void FUN_0040533c(VARIANTARG **param_1,int param_2,int param_3);
int * FUN_00405348(int *param_1,int param_2);
void FUN_00405384(int *param_1,int param_2,int param_3);
PVOID FUN_004053ac(LPCVOID param_1);
void FUN_004053d4(LPCVOID param_1);
int FUN_004053dc(int param_1);
void thunk_FUN_00405408(LPCSTR param_1);
void FUN_00405408(LPCSTR param_1);
char * FUN_00405414(char *param_1);
HMODULE FUN_004055bc(LPCSTR param_1);
void FUN_004057b8(undefined4 param_1);
void FUN_004057c0(int *param_1);
void FUN_004057c8(undefined4 param_1);
void FUN_004057e8(int *param_1);
void FUN_00405848(undefined4 param_1,undefined4 param_2,undefined *param_3);
void FUN_004058a4(undefined4 *param_1);
void FUN_004058b4(undefined4 *param_1,undefined4 param_2,undefined *param_3);
void FUN_00405924(int **param_1,int *param_2);
int ** FUN_0040597c(int **param_1);
void FUN_00405994(int **param_1,int *param_2);
void FUN_004059b0(int *param_1);
LONG FUN_00405a24(undefined param_1,undefined param_2,undefined param_3,int *param_4);
DWORD __stdcall GetCurrentThreadId(void);
void FUN_00405c56(undefined4 *param_1,char *param_2);
void FUN_00405cf8(undefined *param_1);
void FUN_00405d76(undefined *param_1);
undefined * FUN_00405d84(undefined *param_1,undefined *param_2,int param_3);
undefined * FUN_00405def(undefined *param_1,int param_2);
void FUN_00405e4f(undefined *param_1);
void FUN_00405ecc(undefined *param_1,char *param_2);
void FUN_00405efc(int param_1);
int FUN_004061d0(int param_1,undefined4 param_2,undefined4 param_3,int param_4);
int FUN_004062c0(int param_1,uint param_2,undefined4 param_3,uint param_4,uint param_5);
uint FUN_004063b5(int param_1,uint param_2,undefined4 param_3,uint param_4,uint param_5);
void FUN_00406458(void);
void FUN_004064c0(void);
DWORD __stdcall GetModuleFileNameA(HMODULE hModule,LPSTR lpFilename,DWORD nSize);
HMODULE __stdcall GetModuleHandleA(LPCSTR lpModuleName);
HLOCAL __stdcall LocalAlloc(UINT uFlags,SIZE_T uBytes);
LPVOID __stdcall TlsGetValue(DWORD dwTlsIndex);
BOOL __stdcall TlsSetValue(DWORD dwTlsIndex,LPVOID lpTlsValue);
void FUN_004065e0(void);
LPVOID FUN_00406630(void);
void FUN_00406674(void);
void FUN_004066c0(undefined4 param_1);
LSTATUS __stdcall RegCloseKey(HKEY hKey);
LSTATUS __stdcall RegCreateKeyExA(HKEY hKey,LPCSTR lpSubKey,DWORD Reserved,LPSTR lpClass,DWORD dwOptions,REGSAM samDesired,LPSECURITY_ATTRIBUTES lpSecurityAttributes,PHKEY phkResult,LPDWORD lpdwDisposition);
LSTATUS __stdcall RegFlushKey(HKEY hKey);
LSTATUS __stdcall RegOpenKeyExA(HKEY hKey,LPCSTR lpSubKey,DWORD ulOptions,REGSAM samDesired,PHKEY phkResult);
LSTATUS __stdcall RegQueryValueExA(HKEY hKey,LPCSTR lpValueName,LPDWORD lpReserved,LPDWORD lpType,LPBYTE lpData,LPDWORD lpcbData);
BOOL __stdcall CloseHandle(HANDLE hObject);
int __stdcall CompareStringA(LCID Locale,DWORD dwCmpFlags,PCNZCH lpString1,int cchCount1,PCNZCH lpString2,int cchCount2);
HANDLE __stdcall CreateEventA(LPSECURITY_ATTRIBUTES lpEventAttributes,BOOL bManualReset,BOOL bInitialState,LPCSTR lpName);
HANDLE __stdcall CreateFileA(LPCSTR lpFileName,DWORD dwDesiredAccess,DWORD dwShareMode,LPSECURITY_ATTRIBUTES lpSecurityAttributes,DWORD dwCreationDisposition,DWORD dwFlagsAndAttributes,HANDLE hTemplateFile);
HANDLE __stdcall CreateSemaphoreA(LPSECURITY_ATTRIBUTES lpSemaphoreAttributes,LONG lInitialCount,LONG lMaximumCount,LPCSTR lpName);
HANDLE __stdcall CreateThread(LPSECURITY_ATTRIBUTES lpThreadAttributes,SIZE_T dwStackSize,LPTHREAD_START_ROUTINE lpStartAddress,LPVOID lpParameter,DWORD dwCreationFlags,LPDWORD lpThreadId);
void __stdcall DeleteCriticalSection(LPCRITICAL_SECTION lpCriticalSection);
void __stdcall EnterCriticalSection(LPCRITICAL_SECTION lpCriticalSection);
BOOL __stdcall EnumCalendarInfoA(CALINFO_ENUMPROCA lpCalInfoEnumProc,LCID Locale,CALID Calendar,CALTYPE CalType);
BOOL __stdcall FileTimeToDosDateTime(FILETIME *lpFileTime,LPWORD lpFatDate,LPWORD lpFatTime);
BOOL __stdcall FileTimeToLocalFileTime(FILETIME *lpFileTime,LPFILETIME lpLocalFileTime);
BOOL __stdcall FindClose(HANDLE hFindFile);
HANDLE __stdcall FindFirstFileA(LPCSTR lpFileName,LPWIN32_FIND_DATAA lpFindFileData);
HRSRC __stdcall FindResourceA(HMODULE hModule,LPCSTR lpName,LPCSTR lpType);
DWORD __stdcall FormatMessageA(DWORD dwFlags,LPCVOID lpSource,DWORD dwMessageId,DWORD dwLanguageId,LPSTR lpBuffer,DWORD nSize,va_list *Arguments);
BOOL __stdcall FreeLibrary(HMODULE hLibModule);
LONG __stdcall InterlockedDecrement(LONG *lpAddend);
LONG __stdcall InterlockedIncrement(LONG *lpAddend);
BOOL __stdcall FreeResource(HGLOBAL hResData);
BOOL __stdcall GetCPInfo(UINT CodePage,LPCPINFO lpCPInfo);
DWORD __stdcall GetCurrentProcessId(void);
DWORD __stdcall GetCurrentThreadId(void);
int __stdcall GetDateFormatA(LCID Locale,DWORD dwFlags,SYSTEMTIME *lpDate,LPCSTR lpFormat,LPSTR lpDateStr,int cchDate);
BOOL __stdcall GetDiskFreeSpaceA(LPCSTR lpRootPathName,LPDWORD lpSectorsPerCluster,LPDWORD lpBytesPerSector,LPDWORD lpNumberOfFreeClusters,LPDWORD lpTotalNumberOfClusters);
BOOL __stdcall GetExitCodeThread(HANDLE hThread,LPDWORD lpExitCode);
DWORD __stdcall GetLastError(void);
void __stdcall GetLocalTime(LPSYSTEMTIME lpSystemTime);
int __stdcall GetLocaleInfoA(LCID Locale,LCTYPE LCType,LPSTR lpLCData,int cchData);
DWORD __stdcall GetModuleFileNameA(HMODULE hModule,LPSTR lpFilename,DWORD nSize);
HMODULE __stdcall GetModuleHandleA(LPCSTR lpModuleName);
DWORD __stdcall GetPrivateProfileStringA(LPCSTR lpAppName,LPCSTR lpKeyName,LPCSTR lpDefault,LPSTR lpReturnedString,DWORD nSize,LPCSTR lpFileName);
FARPROC __stdcall GetProcAddress(HMODULE hModule,LPCSTR lpProcName);
UINT __stdcall GetProfileIntA(LPCSTR lpAppName,LPCSTR lpKeyName,INT nDefault);
void __stdcall GetSystemInfo(LPSYSTEM_INFO lpSystemInfo);
LCID __stdcall GetThreadLocale(void);
DWORD __stdcall GetTickCount(void);
DWORD __stdcall GetVersion(void);
BOOL __stdcall GetVersionExA(LPOSVERSIONINFOA lpVersionInformation);
ATOM __stdcall GlobalAddAtomA(LPCSTR lpString);
HGLOBAL __stdcall GlobalAlloc(UINT uFlags,SIZE_T dwBytes);
ATOM __stdcall GlobalDeleteAtom(ATOM nAtom);
HGLOBAL __stdcall GlobalFree(HGLOBAL hMem);
LPVOID __stdcall GlobalLock(HGLOBAL hMem);
HGLOBAL __stdcall GlobalHandle(LPCVOID pMem);
HGLOBAL __stdcall GlobalReAlloc(HGLOBAL hMem,SIZE_T dwBytes,UINT uFlags);
BOOL __stdcall GlobalUnlock(HGLOBAL hMem);
void __stdcall InitializeCriticalSection(LPCRITICAL_SECTION lpCriticalSection);
void __stdcall LeaveCriticalSection(LPCRITICAL_SECTION lpCriticalSection);
HMODULE __stdcall LoadLibraryA(LPCSTR lpLibFileName);
HGLOBAL __stdcall LoadResource(HMODULE hModule,HRSRC hResInfo);
LPVOID __stdcall LockResource(HGLOBAL hResData);
int __stdcall MulDiv(int nNumber,int nNumerator,int nDenominator);
BOOL __stdcall ReadFile(HANDLE hFile,LPVOID lpBuffer,DWORD nNumberOfBytesToRead,LPDWORD lpNumberOfBytesRead,LPOVERLAPPED lpOverlapped);
DWORD __stdcall ResumeThread(HANDLE hThread);
BOOL __stdcall SetEndOfFile(HANDLE hFile);
UINT __stdcall SetErrorMode(UINT uMode);
BOOL __stdcall SetEvent(HANDLE hEvent);
DWORD __stdcall SetFilePointer(HANDLE hFile,LONG lDistanceToMove,PLONG lpDistanceToMoveHigh,DWORD dwMoveMethod);
BOOL __stdcall SetThreadLocale(LCID Locale);
DWORD __stdcall SizeofResource(HMODULE hModule,HRSRC hResInfo);
void __stdcall Sleep(DWORD dwMilliseconds);
LPVOID __stdcall VirtualAlloc(LPVOID lpAddress,SIZE_T dwSize,DWORD flAllocationType,DWORD flProtect);
SIZE_T __stdcall VirtualQuery(LPCVOID lpAddress,PMEMORY_BASIC_INFORMATION lpBuffer,SIZE_T dwLength);
DWORD __stdcall WaitForSingleObject(HANDLE hHandle,DWORD dwMilliseconds);
BOOL __stdcall WriteFile(HANDLE hFile,LPCVOID lpBuffer,DWORD nNumberOfBytesToWrite,LPDWORD lpNumberOfBytesWritten,LPOVERLAPPED lpOverlapped);
BOOL __stdcall WritePrivateProfileStringA(LPCSTR lpAppName,LPCSTR lpKeyName,LPCSTR lpString,LPCSTR lpFileName);
int __stdcall lstrcmpA(LPCSTR lpString1,LPCSTR lpString2);
LPSTR __stdcall lstrcpyA(LPSTR lpString1,LPCSTR lpString2);
BOOL __stdcall GetFileVersionInfoA(LPCSTR lptstrFilename,DWORD dwHandle,DWORD dwLen,LPVOID lpData);
DWORD __stdcall GetFileVersionInfoSizeA(LPCSTR lptstrFilename,LPDWORD lpdwHandle);
BOOL __stdcall VerQueryValueA(LPCVOID pBlock,LPCSTR lpSubBlock,LPVOID *lplpBuffer,PUINT puLen);
BOOL __stdcall BitBlt(HDC hdc,int x,int y,int cx,int cy,HDC hdcSrc,int x1,int y1,DWORD rop);
int __stdcall CombineRgn(HRGN hrgnDst,HRGN hrgnSrc1,HRGN hrgnSrc2,int iMode);
HENHMETAFILE __stdcall CopyEnhMetaFileA(HENHMETAFILE hEnh,LPCSTR lpFileName);
HBITMAP __stdcall CreateBitmap(int nWidth,int nHeight,UINT nPlanes,UINT nBitCount,void *lpBits);
HBRUSH __stdcall CreateBrushIndirect(LOGBRUSH *plbrush);
HBITMAP __stdcall CreateCompatibleBitmap(HDC hdc,int cx,int cy);
HDC __stdcall CreateCompatibleDC(HDC hdc);
HBITMAP __stdcall CreateDIBSection(HDC hdc,BITMAPINFO *lpbmi,UINT usage,void **ppvBits,HANDLE hSection,DWORD offset);
HBITMAP __stdcall CreateDIBitmap(HDC hdc,BITMAPINFOHEADER *pbmih,DWORD flInit,void *pjBits,BITMAPINFO *pbmi,UINT iUsage);
HFONT __stdcall CreateFontIndirectA(LOGFONTA *lplf);
HPALETTE __stdcall CreateHalftonePalette(HDC hdc);
HPALETTE __stdcall CreatePalette(LOGPALETTE *plpal);
HPEN __stdcall CreatePenIndirect(LOGPEN *plpen);
HRGN __stdcall CreateRectRgn(int x1,int y1,int x2,int y2);
HBRUSH __stdcall CreateSolidBrush(COLORREF color);
BOOL __stdcall DeleteDC(HDC hdc);
BOOL __stdcall DeleteEnhMetaFile(HENHMETAFILE hmf);
BOOL __stdcall DeleteObject(HGDIOBJ ho);
int __stdcall ExcludeClipRect(HDC hdc,int left,int top,int right,int bottom);
BOOL __stdcall ExtTextOutA(HDC hdc,int x,int y,UINT options,RECT *lprect,LPCSTR lpString,UINT c,INT *lpDx);
LONG __stdcall GetBitmapBits(HBITMAP hbit,LONG cb,LPVOID lpvBits);
BOOL __stdcall GetBrushOrgEx(HDC hdc,LPPOINT lppt);
int __stdcall GetClipBox(HDC hdc,LPRECT lprect);
BOOL __stdcall GetCurrentPositionEx(HDC hdc,LPPOINT lppt);
BOOL __stdcall GetDCOrgEx(HDC hdc,LPPOINT lppt);
UINT __stdcall GetDIBColorTable(HDC hdc,UINT iStart,UINT cEntries,RGBQUAD *prgbq);
int __stdcall GetDIBits(HDC hdc,HBITMAP hbm,UINT start,UINT cLines,LPVOID lpvBits,LPBITMAPINFO lpbmi,UINT usage);
int __stdcall GetDeviceCaps(HDC hdc,int index);
UINT __stdcall GetEnhMetaFileBits(HENHMETAFILE hEMF,UINT nSize,LPBYTE lpData);
UINT __stdcall GetEnhMetaFileHeader(HENHMETAFILE hemf,UINT nSize,LPENHMETAHEADER lpEnhMetaHeader);
UINT __stdcall GetEnhMetaFilePaletteEntries(HENHMETAFILE hemf,UINT nNumEntries,LPPALETTEENTRY lpPaletteEntries);
int __stdcall GetObjectA(HANDLE h,int c,LPVOID pv);
UINT __stdcall GetPaletteEntries(HPALETTE hpal,UINT iStart,UINT cEntries,LPPALETTEENTRY pPalEntries);
COLORREF __stdcall GetPixel(HDC hdc,int x,int y);
int __stdcall GetRgnBox(HRGN hrgn,LPRECT lprc);
HGDIOBJ __stdcall GetStockObject(int i);
UINT __stdcall GetSystemPaletteEntries(HDC hdc,UINT iStart,UINT cEntries,LPPALETTEENTRY pPalEntries);
BOOL __stdcall GetTextExtentPoint32A(HDC hdc,LPCSTR lpString,int c,LPSIZE psizl);
BOOL __stdcall GetTextExtentPointA(HDC hdc,LPCSTR lpString,int c,LPSIZE lpsz);
BOOL __stdcall GetTextMetricsA(HDC hdc,LPTEXTMETRICA lptm);
UINT __stdcall GetWinMetaFileBits(HENHMETAFILE hemf,UINT cbData16,LPBYTE pData16,INT iMapMode,HDC hdcRef);
BOOL __stdcall GetWindowOrgEx(HDC hdc,LPPOINT lppoint);
int __stdcall IntersectClipRect(HDC hdc,int left,int top,int right,int bottom);
BOOL __stdcall LineTo(HDC hdc,int x,int y);
BOOL __stdcall MaskBlt(HDC hdcDest,int xDest,int yDest,int width,int height,HDC hdcSrc,int xSrc,int ySrc,HBITMAP hbmMask,int xMask,int yMask,DWORD rop);
BOOL __stdcall MoveToEx(HDC hdc,int x,int y,LPPOINT lppt);
BOOL __stdcall PatBlt(HDC hdc,int x,int y,int w,int h,DWORD rop);
BOOL __stdcall PlayEnhMetaFile(HDC hdc,HENHMETAFILE hmf,RECT *lprect);
BOOL __stdcall Polyline(HDC hdc,POINT *apt,int cpt);
UINT __stdcall RealizePalette(HDC hdc);
BOOL __stdcall RectVisible(HDC hdc,RECT *lprect);
BOOL __stdcall Rectangle(HDC hdc,int left,int top,int right,int bottom);
BOOL __stdcall RestoreDC(HDC hdc,int nSavedDC);
int __stdcall SaveDC(HDC hdc);
HGDIOBJ __stdcall SelectObject(HDC hdc,HGDIOBJ h);
HPALETTE __stdcall SelectPalette(HDC hdc,HPALETTE hPal,BOOL bForceBkgd);
COLORREF __stdcall SetBkColor(HDC hdc,COLORREF color);
int __stdcall SetBkMode(HDC hdc,int mode);
BOOL __stdcall SetBrushOrgEx(HDC hdc,int x,int y,LPPOINT lppt);
UINT __stdcall SetDIBColorTable(HDC hdc,UINT iStart,UINT cEntries,RGBQUAD *prgbq);
HENHMETAFILE __stdcall SetEnhMetaFileBits(UINT nSize,BYTE *pb);
COLORREF __stdcall SetPixel(HDC hdc,int x,int y,COLORREF color);
int __stdcall SetROP2(HDC hdc,int rop2);
int __stdcall SetStretchBltMode(HDC hdc,int mode);
COLORREF __stdcall SetTextColor(HDC hdc,COLORREF color);
BOOL __stdcall SetViewportOrgEx(HDC hdc,int x,int y,LPPOINT lppt);
HENHMETAFILE __stdcall SetWinMetaFileBits(UINT nSize,BYTE *lpMeta16Data,HDC hdcRef,METAFILEPICT *lpMFP);
BOOL __stdcall SetWindowOrgEx(HDC hdc,int x,int y,LPPOINT lppt);
BOOL __stdcall StretchBlt(HDC hdcDest,int xDest,int yDest,int wDest,int hDest,HDC hdcSrc,int xSrc,int ySrc,int wSrc,int hSrc,DWORD rop);
BOOL __stdcall UnrealizeObject(HGDIOBJ h);
HKL __stdcall ActivateKeyboardLayout(HKL hkl,UINT Flags);
BOOL __stdcall AdjustWindowRectEx(LPRECT lpRect,DWORD dwStyle,BOOL bMenu,DWORD dwExStyle);
LPSTR __stdcall CharLowerA(LPSTR lpsz);
HDC __stdcall BeginPaint(HWND hWnd,LPPAINTSTRUCT lpPaint);
LRESULT __stdcall CallNextHookEx(HHOOK hhk,int nCode,WPARAM wParam,LPARAM lParam);
LRESULT __stdcall CallWindowProcA(WNDPROC lpPrevWndFunc,HWND hWnd,UINT Msg,WPARAM wParam,LPARAM lParam);
DWORD __stdcall CharLowerBuffA(LPSTR lpsz,DWORD cchLength);
DWORD __stdcall CheckMenuItem(HMENU hMenu,UINT uIDCheckItem,UINT uCheck);
HWND __stdcall ChildWindowFromPoint(HWND hWndParent,POINT Point);
BOOL __stdcall ClientToScreen(HWND hWnd,LPPOINT lpPoint);
BOOL __stdcall CloseClipboard(void);
HICON __stdcall CreateIcon(HINSTANCE hInstance,int nWidth,int nHeight,BYTE cPlanes,BYTE cBitsPixel,BYTE *lpbANDbits,BYTE *lpbXORbits);
HMENU __stdcall CreateMenu(void);
HMENU __stdcall CreatePopupMenu(void);
HWND __stdcall CreateWindowExA(DWORD dwExStyle,LPCSTR lpClassName,LPCSTR lpWindowName,DWORD dwStyle,int X,int Y,int nWidth,int nHeight,HWND hWndParent,HMENU hMenu,HINSTANCE hInstance,LPVOID lpParam);
LRESULT __stdcall DefFrameProcA(HWND hWnd,HWND hWndMDIClient,UINT uMsg,WPARAM wParam,LPARAM lParam);
LRESULT __stdcall DefWindowProcA(HWND hWnd,UINT Msg,WPARAM wParam,LPARAM lParam);
BOOL __stdcall DeleteMenu(HMENU hMenu,UINT uPosition,UINT uFlags);
BOOL __stdcall DestroyCursor(HCURSOR hCursor);
BOOL __stdcall DestroyIcon(HICON hIcon);
BOOL __stdcall DestroyMenu(HMENU hMenu);
BOOL __stdcall DestroyWindow(HWND hWnd);
LRESULT __stdcall DispatchMessageA(MSG *lpMsg);
BOOL __stdcall DrawEdge(HDC hdc,LPRECT qrc,UINT edge,UINT grfFlags);
BOOL __stdcall DrawFocusRect(HDC hDC,RECT *lprc);
BOOL __stdcall DrawFrameControl(HDC param_1,LPRECT param_2,UINT param_3,UINT param_4);
BOOL __stdcall DrawIcon(HDC hDC,int X,int Y,HICON hIcon);
BOOL __stdcall DrawIconEx(HDC hdc,int xLeft,int yTop,HICON hIcon,int cxWidth,int cyWidth,UINT istepIfAniCur,HBRUSH hbrFlickerFreeDraw,UINT diFlags);
BOOL __stdcall DrawMenuBar(HWND hWnd);
int __stdcall DrawTextA(HDC hdc,LPCSTR lpchText,int cchText,LPRECT lprc,UINT format);
BOOL __stdcall EmptyClipboard(void);
BOOL __stdcall EnableMenuItem(HMENU hMenu,UINT uIDEnableItem,UINT uEnable);
BOOL __stdcall EnableWindow(HWND hWnd,BOOL bEnable);
BOOL __stdcall EndPaint(HWND hWnd,PAINTSTRUCT *lpPaint);
UINT __stdcall EnumClipboardFormats(UINT format);
BOOL __stdcall EnumThreadWindows(DWORD dwThreadId,WNDENUMPROC lpfn,LPARAM lParam);
BOOL __stdcall EnumWindows(WNDENUMPROC lpEnumFunc,LPARAM lParam);
BOOL __stdcall EqualRect(RECT *lprc1,RECT *lprc2);
int __stdcall FillRect(HDC hDC,RECT *lprc,HBRUSH hbr);
HWND __stdcall FindWindowA(LPCSTR lpClassName,LPCSTR lpWindowName);
int __stdcall FrameRect(HDC hDC,RECT *lprc,HBRUSH hbr);
HWND __stdcall GetActiveWindow(void);
HWND __stdcall GetCapture(void);
BOOL __stdcall GetClassInfoA(HINSTANCE hInstance,LPCSTR lpClassName,LPWNDCLASSA lpWndClass);
int __stdcall GetClassNameA(HWND hWnd,LPSTR lpClassName,int nMaxCount);
BOOL __stdcall GetClientRect(HWND hWnd,LPRECT lpRect);
HANDLE __stdcall GetClipboardData(UINT uFormat);
HCURSOR __stdcall GetCursor(void);
BOOL __stdcall GetCursorPos(LPPOINT lpPoint);
HDC __stdcall GetDC(HWND hWnd);
HDC __stdcall GetDCEx(HWND hWnd,HRGN hrgnClip,DWORD flags);
HWND __stdcall GetDesktopWindow(void);
HWND __stdcall GetDlgItem(HWND hDlg,int nIDDlgItem);
HWND __stdcall GetFocus(void);
HWND __stdcall GetForegroundWindow(void);
BOOL __stdcall GetIconInfo(HICON hIcon,PICONINFO piconinfo);
int __stdcall GetKeyNameTextA(LONG lParam,LPSTR lpString,int cchSize);
SHORT __stdcall GetKeyState(int nVirtKey);
HKL __stdcall GetKeyboardLayout(DWORD idThread);
int __stdcall GetKeyboardLayoutList(int nBuff,HKL *lpList);
BOOL __stdcall GetKeyboardState(PBYTE lpKeyState);
HWND __stdcall GetLastActivePopup(HWND hWnd);
HMENU __stdcall GetMenu(HWND hWnd);
int __stdcall GetMenuItemCount(HMENU hMenu);
UINT __stdcall GetMenuItemID(HMENU hMenu,int nPos);
BOOL __stdcall GetMenuItemInfoA(HMENU hmenu,UINT item,BOOL fByPosition,LPMENUITEMINFOA lpmii);
UINT __stdcall GetMenuState(HMENU hMenu,UINT uId,UINT uFlags);
int __stdcall GetMenuStringA(HMENU hMenu,UINT uIDItem,LPSTR lpString,int cchMax,UINT flags);
DWORD __stdcall GetMessagePos(void);
HWND __stdcall GetWindow(HWND hWnd,UINT uCmd);
HWND __stdcall GetParent(HWND hWnd);
HANDLE __stdcall GetPropA(HWND hWnd,LPCSTR lpString);
HMENU __stdcall GetSubMenu(HMENU hMenu,int nPos);
DWORD __stdcall GetSysColor(int nIndex);
HMENU __stdcall GetSystemMenu(HWND hWnd,BOOL bRevert);
int __stdcall GetSystemMetrics(int nIndex);
HWND __stdcall GetTopWindow(HWND hWnd);
HWND __stdcall GetWindow(HWND hWnd,UINT uCmd);
HDC __stdcall GetWindowDC(HWND hWnd);
LONG __stdcall GetWindowLongA(HWND hWnd,int nIndex);
BOOL __stdcall GetWindowPlacement(HWND hWnd,WINDOWPLACEMENT *lpwndpl);
BOOL __stdcall GetWindowRect(HWND hWnd,LPRECT lpRect);
int __stdcall GetWindowTextA(HWND hWnd,LPSTR lpString,int nMaxCount);
DWORD __stdcall GetWindowThreadProcessId(HWND hWnd,LPDWORD lpdwProcessId);
BOOL __stdcall InflateRect(LPRECT lprc,int dx,int dy);
BOOL __stdcall InsertMenuA(HMENU hMenu,UINT uPosition,UINT uFlags,UINT_PTR uIDNewItem,LPCSTR lpNewItem);
BOOL __stdcall InsertMenuItemA(HMENU hmenu,UINT item,BOOL fByPosition,LPCMENUITEMINFOA lpmi);
BOOL __stdcall IntersectRect(LPRECT lprcDst,RECT *lprcSrc1,RECT *lprcSrc2);
BOOL __stdcall InvalidateRect(HWND hWnd,RECT *lpRect,BOOL bErase);
BOOL __stdcall IsChild(HWND hWndParent,HWND hWnd);
BOOL __stdcall IsClipboardFormatAvailable(UINT format);
BOOL __stdcall IsDialogMessageA(HWND hDlg,LPMSG lpMsg);
BOOL __stdcall IsIconic(HWND hWnd);
BOOL __stdcall IsRectEmpty(RECT *lprc);
BOOL __stdcall IsWindow(HWND hWnd);
BOOL __stdcall IsWindowEnabled(HWND hWnd);
BOOL __stdcall IsWindowVisible(HWND hWnd);
BOOL __stdcall KillTimer(HWND hWnd,UINT_PTR uIDEvent);
HBITMAP __stdcall LoadBitmapA(HINSTANCE hInstance,LPCSTR lpBitmapName);
HCURSOR __stdcall LoadCursorA(HINSTANCE hInstance,LPCSTR lpCursorName);
HICON __stdcall LoadIconA(HINSTANCE hInstance,LPCSTR lpIconName);
HKL __stdcall LoadKeyboardLayoutA(LPCSTR pwszKLID,UINT Flags);
int __stdcall LoadStringA(HINSTANCE hInstance,UINT uID,LPSTR lpBuffer,int cchBufferMax);
UINT __stdcall MapVirtualKeyA(UINT uCode,UINT uMapType);
int __stdcall MapWindowPoints(HWND hWndFrom,HWND hWndTo,LPPOINT lpPoints,UINT cPoints);
BOOL __stdcall MessageBeep(UINT uType);
int __stdcall MessageBoxA(HWND hWnd,LPCSTR lpText,LPCSTR lpCaption,UINT uType);
DWORD __stdcall MsgWaitForMultipleObjects(DWORD nCount,HANDLE *pHandles,BOOL fWaitAll,DWORD dwMilliseconds,DWORD dwWakeMask);
BOOL __stdcall OemToCharA(LPCSTR pSrc,LPSTR pDst);
BOOL __stdcall OffsetRect(LPRECT lprc,int dx,int dy);
BOOL __stdcall OpenClipboard(HWND hWndNewOwner);
BOOL __stdcall PeekMessageA(LPMSG lpMsg,HWND hWnd,UINT wMsgFilterMin,UINT wMsgFilterMax,UINT wRemoveMsg);
BOOL __stdcall PostMessageA(HWND hWnd,UINT Msg,WPARAM wParam,LPARAM lParam);
void __stdcall PostQuitMessage(int nExitCode);
BOOL __stdcall PtInRect(RECT *lprc,POINT pt);
BOOL __stdcall RedrawWindow(HWND hWnd,RECT *lprcUpdate,HRGN hrgnUpdate,UINT flags);
ATOM __stdcall RegisterClassA(WNDCLASSA *lpWndClass);
UINT __stdcall RegisterClipboardFormatA(LPCSTR lpszFormat);
UINT __stdcall RegisterWindowMessageA(LPCSTR lpString);
BOOL __stdcall ReleaseCapture(void);
int __stdcall ReleaseDC(HWND hWnd,HDC hDC);
BOOL __stdcall RemoveMenu(HMENU hMenu,UINT uPosition,UINT uFlags);
HANDLE __stdcall RemovePropA(HWND hWnd,LPCSTR lpString);
BOOL __stdcall ScreenToClient(HWND hWnd,LPPOINT lpPoint);
BOOL __stdcall ScrollWindow(HWND hWnd,int XAmount,int YAmount,RECT *lpRect,RECT *lpClipRect);
LRESULT __stdcall SendMessageA(HWND hWnd,UINT Msg,WPARAM wParam,LPARAM lParam);
HWND __stdcall SetActiveWindow(HWND hWnd);
HWND __stdcall SetCapture(HWND hWnd);
DWORD __stdcall SetClassLongA(HWND hWnd,int nIndex,LONG dwNewLong);
HANDLE __stdcall SetClipboardData(UINT uFormat,HANDLE hMem);
HCURSOR __stdcall SetCursor(HCURSOR hCursor);
HWND __stdcall SetFocus(HWND hWnd);
BOOL __stdcall SetForegroundWindow(HWND hWnd);
BOOL __stdcall SetMenu(HWND hWnd,HMENU hMenu);
BOOL __stdcall SetMenuItemInfoA(HMENU hmenu,UINT item,BOOL fByPositon,LPCMENUITEMINFOA lpmii);
BOOL __stdcall SetPropA(HWND hWnd,LPCSTR lpString,HANDLE hData);
BOOL __stdcall SetRect(LPRECT lprc,int xLeft,int yTop,int xRight,int yBottom);
UINT_PTR __stdcall SetTimer(HWND hWnd,UINT_PTR nIDEvent,UINT uElapse,TIMERPROC lpTimerFunc);
LONG __stdcall SetWindowLongA(HWND hWnd,int nIndex,LONG dwNewLong);
BOOL __stdcall SetWindowPlacement(HWND hWnd,WINDOWPLACEMENT *lpwndpl);
BOOL __stdcall SetWindowPos(HWND hWnd,HWND hWndInsertAfter,int X,int Y,int cx,int cy,UINT uFlags);
BOOL __stdcall SetWindowTextA(HWND hWnd,LPCSTR lpString);
HHOOK __stdcall SetWindowsHookExA(int idHook,HOOKPROC lpfn,HINSTANCE hmod,DWORD dwThreadId);
int __stdcall ShowCursor(BOOL bShow);
BOOL __stdcall ShowOwnedPopups(HWND hWnd,BOOL fShow);
BOOL __stdcall ShowWindow(HWND hWnd,int nCmdShow);
BOOL __stdcall SystemParametersInfoA(UINT uiAction,UINT uiParam,PVOID pvParam,UINT fWinIni);
BOOL __stdcall TrackPopupMenu(HMENU hMenu,UINT uFlags,int x,int y,int nReserved,HWND hWnd,RECT *prcRect);
BOOL __stdcall TranslateMDISysAccel(HWND hWndClient,LPMSG lpMsg);
BOOL __stdcall TranslateMessage(MSG *lpMsg);
BOOL __stdcall UnhookWindowsHookEx(HHOOK hhk);
BOOL __stdcall UnionRect(LPRECT lprcDst,RECT *lprcSrc1,RECT *lprcSrc2);
BOOL __stdcall UnregisterClassA(LPCSTR lpClassName,HINSTANCE hInstance);
BOOL __stdcall UpdateWindow(HWND hWnd);
BOOL __stdcall WaitMessage(void);
BOOL __stdcall WinHelpA(HWND hWndMain,LPCSTR lpszHelp,UINT uCommand,ULONG_PTR dwData);
HWND __stdcall WindowFromPoint(POINT Point);
uint FUN_00407104(uint param_1,int param_2);
uint FUN_00407110(uint param_1);
uint FUN_00407114(uint param_1);
void FUN_0040711c(void);
undefined4 FUN_0040712c(void);
void FUN_00407130(UINT param_1,SIZE_T param_2);
void FUN_00407140(LPCVOID param_1,SIZE_T param_2,UINT param_3);
void FUN_0040715c(LPCVOID param_1);
uint FUN_00407170(uint param_1,uint param_2);
uint FUN_0040717c(uint param_1,uint param_2,byte param_3);
void FUN_00407198(void);
uint FUN_0040719c(uint param_1);
uint FUN_004071a0(uint param_1);
void FUN_004071a4(undefined4 param_1,int *param_2);
undefined4 FUN_004071b8(undefined2 *param_1);
void FUN_004071d0(uint param_1,int param_2);
void FUN_004071d8(LPCSTR param_1,LPCSTR param_2,DWORD param_3,LPVOID param_4,HINSTANCE param_5,HMENU param_6,HWND param_7,int param_8,int param_9,int param_10,int param_11);
HWND FUN_0040720c(UINT *param_1,UINT *param_2,UINT *param_3,LRESULT *param_4,LRESULT *param_5);
void FUN_0040816c(uint param_1,uint param_2,undefined2 *param_3,undefined2 *param_4);
void FUN_00408188(int **param_1,undefined4 param_2,undefined4 param_3);
undefined4 * FUN_004081e8(uint param_1);
void FUN_00408234(undefined4 param_1);
void FUN_0040826c(byte *param_1,byte **param_2);
void FUN_004082a8(byte *param_1,byte **param_2);
undefined4 FUN_004082e4(int *param_1,int *param_2,uint param_3);
char * FUN_00408304(char *param_1,char *param_2);
undefined4 FUN_00408358(char *param_1,char *param_2);
void FUN_0040837c(undefined *param_1,LPSTR *param_2);
int FUN_004083b0(undefined *param_1,undefined *param_2);
uint FUN_004083e8(undefined *param_1,undefined *param_2);
int FUN_00408424(PCNZCH param_1,PCNZCH param_2,int param_3);
void FUN_00408444(int param_1,int *param_2);
void FUN_00408494(undefined4 *param_1,byte **param_2);
undefined4 FUN_00408560(char *param_1);
void FUN_004085c4(undefined4 param_1,byte **param_2);
undefined4 FUN_004085f4(byte *param_1);
undefined4 FUN_00408630(byte *param_1,undefined4 param_2,byte *param_3);
void FUN_00408648(undefined *param_1,uint param_2);
void FUN_00408688(undefined *param_1);
DWORD FUN_004086ac(HANDLE param_1,LPVOID param_2,DWORD param_3);
DWORD FUN_004086d8(HANDLE param_1,LPCVOID param_2,DWORD param_3);
void FUN_00408704(HANDLE param_1,LONG param_2,DWORD param_3);
void FUN_00408710(HANDLE param_1);
undefined4 FUN_00408718(undefined *param_1);
uint FUN_00408780(undefined *param_1);
undefined * FUN_00408790(undefined *param_1);
int FUN_004087c0(undefined *param_1,undefined *param_2);
void FUN_00408810(undefined *param_1,int *param_2);
void FUN_00408844(undefined *param_1,int *param_2);
void FUN_0040887c(undefined *param_1,int *param_2);
int FUN_00408954(char *param_1);
char * FUN_0040896c(char *param_1);
void FUN_00408980(undefined4 *param_1,undefined4 *param_2,uint param_3);
undefined4 * FUN_004089bc(undefined4 *param_1,undefined4 *param_2);
undefined4 * FUN_004089e4(undefined4 *param_1,undefined4 *param_2,int param_3);
void FUN_00408a18(undefined4 *param_1,undefined *param_2);
void FUN_00408a3c(undefined4 *param_1,undefined *param_2,int param_3);
int FUN_00408a5c(char *param_1,char *param_2);
void FUN_00408a80(char *param_1,char *param_2,int param_3);
char * FUN_00408ac8(char *param_1,char param_2);
char * FUN_00408ae8(char *param_1,char param_2);
char * FUN_00408b0c(char *param_1,char *param_2);
void FUN_00408b60(undefined4 *param_1,int *param_2);
int * FUN_00408b74(int param_1);
int FUN_00408b88(int param_1);
undefined4 FUN_00408b94(undefined4 *param_1);
void FUN_00408bc0(int param_1);
void FUN_00408bd0(int param_1,undefined4 *param_2,uint param_3);
void FUN_00408c3c(int *param_1);
void FUN_00408c48(byte *param_1,byte *param_2,byte *param_3,undefined4 param_4,undefined4 param_5,int param_6);
uint FUN_00408d2a(uint param_1,undefined4 param_2,byte *param_3);
void FUN_00408d73(byte param_1,undefined4 param_2,uint param_3);
void FUN_00408e33(void);
void FUN_00408eba(uint param_1);
undefined4 FUN_00409025(undefined4 param_1);
byte * FUN_00409040(byte *param_1,byte *param_2,undefined4 param_3,undefined4 param_4);
byte * FUN_00409074(byte *param_1,byte *param_2,byte *param_3,undefined4 param_4,undefined4 param_5);
void FUN_004090a8(byte *param_1,undefined4 param_2,undefined4 param_3,byte **param_4);
void FUN_004090bc(byte **param_1,byte *param_2,undefined4 param_3,undefined4 param_4);
void FUN_00409184(int *param_1,undefined param_2,undefined param_3,undefined param_4);
void FUN_004091b4(undefined *param_1);
void FUN_004091f0(undefined4 *param_1,undefined4 param_2,undefined4 param_3,double param_4);
uint FUN_00409230(double *param_1,ushort param_2,ushort param_3,double *param_4,ushort param_5);
void FUN_004092a0(undefined2 *param_1,undefined2 *param_2,undefined2 *param_3,undefined2 *param_4,undefined4 param_5,undefined4 param_6);
undefined4 FUN_004092fc(uint param_1);
uint FUN_00409338(uint param_1,ushort param_2,ushort param_3,double *param_4);
void FUN_00409400(ushort *param_1,ushort *param_2,short *param_3,undefined2 *param_4,undefined4 param_5,undefined4 param_6);
void FUN_00409544(ushort *param_1,ushort *param_2,short *param_3,undefined4 param_4,undefined4 param_5);
int FUN_00409564(undefined4 param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4,undefined4 param_5);
WORD FUN_0040958c(void);
void FUN_004095a0(undefined4 *param_1,uint param_2,undefined4 param_3,int param_4);
void FUN_004095e4(undefined4 *param_1,undefined4 param_2,undefined4 param_3,int param_4);
void FUN_00409604(undefined4 param_1,undefined4 param_2,undefined4 param_3,int param_4);
void FUN_00409650(undefined param_1,undefined param_2,undefined param_3,int param_4);
void FUN_0040967c(undefined param_1,undefined param_2,undefined param_3,int param_4);
void FUN_004096b4(undefined param_1,undefined param_2,undefined param_3,int param_4);
void FUN_004096f4(int param_1,int *param_2,undefined4 param_3,int param_4);
void FUN_00409860(int param_1,char **param_2,undefined4 param_3,int param_4);
void FUN_00409968(undefined4 *param_1,undefined4 param_2,undefined *param_3,undefined *param_4);
void FUN_0040a0dc(int *param_1,undefined4 *param_2,undefined *param_3);
void FUN_0040a138(int *param_1,undefined4 param_2,undefined *param_3,undefined4 param_4,undefined4 param_5);
void FUN_0040a150(int *param_1,undefined4 param_2,undefined *param_3,undefined4 param_4,undefined4 param_5);
void FUN_0040a168(int *param_1,undefined4 param_2,undefined *param_3,undefined4 param_4,undefined4 param_5);
void FUN_0040a17c(int param_1,int *param_2);
uint FUN_0040a1a0(int param_1,int *param_2,int *param_3,char *param_4);
void FUN_0040a234(int param_1,int *param_2,undefined *param_3);
undefined4 FUN_0040a2c0(int param_1,int *param_2,char param_3);
undefined4 FUN_0040a2f8(int param_1);
uint FUN_0040a344(int param_1,uint *param_2);
undefined4 FUN_0040a380(undefined *param_1);
int FUN_0040a3d4(int param_1,undefined4 param_2,undefined4 param_3,int param_4);
void FUN_0040a430(int param_1,uint *param_2,double *param_3);
uint FUN_0040a76c(int param_1,int *param_2,double *param_3);
void FUN_0040a960(int param_1);
void FUN_0040a9b0(int param_1);
void FUN_0040aa00(int param_1);
void FUN_0040aac4(DWORD param_1,int *param_2);
void FUN_0040ab10(LCID param_1,LCTYPE param_2,undefined4 *param_3,int *param_4);
uint FUN_0040ab5c(LCID param_1,LCTYPE param_2,uint param_3);
void FUN_0040ab84(LCTYPE param_1,int param_2,int param_3,int *param_4,undefined4 param_5,int param_6);
void FUN_0040abc0(void);
void FUN_0040ad98(void);
void FUN_0040ae48(undefined4 *param_1,int *param_2);
int FUN_0040b098(int param_1);
void FUN_0040b0a4(int *param_1,LPCVOID param_2,byte *param_3,byte *param_4);
void FUN_0040b22c(int *param_1,LPCVOID param_2);
int * FUN_0040b2a4(int *param_1,char param_2,undefined4 *param_3);
void FUN_0040b2e0(int param_1,char param_2,byte *param_3,undefined4 param_4,undefined4 param_5);
int * FUN_0040b360(int *param_1,char param_2,int **param_3);
void FUN_0040b39c(int param_1,char param_2,int **param_3,undefined4 param_4,undefined4 param_5);
void FUN_0040b45c(void);
void FUN_0040b520(int param_1,undefined4 param_2,undefined4 param_3);
void FUN_0040b5cc(undefined4 param_1,undefined4 param_2,undefined4 *param_3);
undefined4 FUN_0040b624(int *param_1);
void FUN_0040b6b8(undefined param_1,undefined param_2,undefined param_3,int param_4);
void FUN_0040b960(void);
void FUN_0040ba2c(void);
void FUN_0040ba98(void);
undefined4 FUN_0040baf0(byte *param_1,int param_2);
undefined4 FUN_0040bb68(undefined *param_1,int param_2);
undefined4 FUN_0040bb8c(byte *param_1,int param_2);
void FUN_0040bba4(int param_1,int param_2);
int FUN_0040bbcc(int param_1,int param_2);
void FUN_0040bc1c(int param_1,int param_2,int *param_3,int *param_4);
int FUN_0040bc90(int param_1,int param_2);
int FUN_0040bcf4(int param_1,int param_2);
undefined4 FUN_0040bd54(undefined *param_1,int param_2);
bool FUN_0040bd88(undefined *param_1,undefined *param_2,int param_3);
PCNZCH FUN_0040bdcc(undefined *param_1,undefined *param_2);
uint FUN_0040be04(undefined *param_1,LPSTR *param_2);
PCNZCH FUN_0040be90(byte *param_1,char *param_2);
char * FUN_0040bf30(byte *param_1,char param_2);
char * FUN_0040bf58(byte *param_1,char param_2);
void FUN_0040bf98(void);
void FUN_0040c050(void);
void FUN_0040c3c8(void);
int FUN_0040c460(int param_1);
void FUN_0040c470(void);
void FUN_0040c48c(void);
void FUN_0040c4ac(void);
int * FUN_0040c508(int *param_1,char param_2,undefined4 param_3);
uint FUN_0040c5b0(int param_1);
void FUN_0040c5ec(int param_1);
void FUN_0040c638(int param_1);
void FUN_0040c65c(int **param_1);
void FUN_0040c66c(undefined *param_1,UINT param_2);
undefined *FUN_0040c9e2(undefined *param_1,undefined4 param_2,char param_3,undefined4 param_4,int param_5,byte param_6);
void FUN_0040caa0(void);
void FUN_0040cf85(undefined4 param_1,undefined4 param_2,char param_3);
void FUN_0040cfac(void);
void FUN_0040d0b3(void);
undefined4 FUN_0040d184(byte *param_1,float10 *param_2,char param_3);
void FUN_0040d22f(void);
void FUN_0040d23a(void);
void FUN_0040d256(void);
void FUN_0040d3c8(void);
void IsEqualGUID(void);
HRESULT __stdcall OleInitialize(LPVOID pvReserved);
void __stdcall OleUninitialize(void);
HRESULT __stdcall RegisterDragDrop(HWND hwnd,LPDROPTARGET pDropTarget);
HRESULT __stdcall RevokeDragDrop(HWND hwnd);
void __stdcall ReleaseStgMedium(LPSTGMEDIUM param_1);
int FUN_0040d8f4(int param_1);
void FUN_0040d900(char *param_1,uint param_2,byte **param_3);
int FUN_0040d9e0(int param_1,int param_2);
void FUN_0040da2c(char *param_1,byte *param_2);
void FUN_0040da40(int param_1,undefined *param_2);
void FUN_0040daac(int param_1,undefined4 *param_2);
uint FUN_0040db00(int *param_1,int param_2);
uint FUN_0040db30(int *param_1,char **param_2);
void FUN_0040dba4(int *param_1,char **param_2,char *param_3);
void FUN_0040dc00(int *param_1,int param_2,byte *param_3);
void FUN_0040dc44(int *param_1,int **param_2,int *param_3);
void FUN_0040dc98(int *param_1,int param_2,int *param_3);
void FUN_0040dcc0(int *param_1,int **param_2,undefined4 *param_3);
void FUN_0040dcf4(int *param_1,undefined4 *param_2);
void FUN_0040dd08(int *param_1,int param_2,int *param_3);
void FUN_0040dd48(int *param_1,int param_2,undefined4 *param_3);
void FUN_0040dd88(BSTR *param_1,OLECHAR *param_2);
void FUN_0040dd9c(int *param_1,int param_2,BSTR *param_3);
void FUN_0040dddc(int *param_1,int param_2,OLECHAR *param_3);
void FUN_0040de1c(int *param_1,int param_2,LPSTR *param_3);
void FUN_0040de68(int *param_1,int param_2,LPCSTR param_3);
void FUN_0040dec0(int *param_1,char **param_2,LPSTR *param_3);
void FUN_0040df00(int *param_1,int **param_2,undefined4 *param_3);
void FUN_0040df2c(int *param_1,int **param_2);
void FUN_0040dfa4(undefined4 param_1,int **param_2,undefined param_3,undefined1 param_4 [10]);
void FUN_0040e03c(VARIANT *param_1,VARIANTARG *param_2);
void FUN_0040e050(int *param_1,int param_2,VARIANT *param_3);
void FUN_0040e090(int *param_1,int param_2,VARIANTARG *param_3);
void FUN_0040e0d0(int *param_1,int param_2,undefined4 *param_3);
void FUN_0040e110(int *param_1,int param_2,undefined4 *param_3);
undefined4 FUN_0040e148(int *param_1,int param_2);
void FUN_0040e170(int *param_1,int param_2,undefined4 param_3,undefined4 param_4,undefined4 param_5);
void FUN_0040e1ac(void);
void FUN_0040f7a0(undefined4 param_1,undefined4 param_2,undefined4 *param_3);
void FUN_0040f7b8(undefined4 param_1,undefined4 param_2,undefined4 param_3,undefined4 *param_4,undefined4 param_5);
void FUN_0040f7d4(int param_1,int param_2,int param_3,int *param_4,int param_5);
int FUN_0040f7f0(int param_1);
void FUN_0040f7fc(undefined4 param_1);
byte * FUN_0040f868(int param_1);
byte * FUN_0040f918(int param_1);
void FUN_0040f938(undefined4 *param_1,char *param_2);
void FUN_0040fa04(undefined **param_1);
void FUN_0040fb00(undefined4 param_1,int param_2);
void FUN_0040fb34(PVOID param_1);
void FUN_0040fc54(int *param_1,char param_2,int param_3,int param_4,int param_5);
void FUN_0040fc8c(int param_1,int param_2,int param_3);
undefined4 FUN_0040fcb8(int param_1);
undefined4 FUN_0040fd3c(int param_1);
undefined4 FUN_0040fdc0(char *param_1,char **param_2,int param_3,int param_4);
uint FUN_0040fe00(uint param_1,int *param_2,uint *param_3,int param_4);
void FUN_0040fe44(undefined *param_1,HMODULE param_2,int **param_3);
void FUN_0040fec8(void);
void FUN_0040ff28(void);
void FUN_0040ff58(void);
void FUN_0040ffcc(undefined **param_1,undefined4 param_2,undefined4 param_3,int param_4);
void FUN_00410074(undefined4 *param_1,undefined4 param_2);
void FUN_00410138(int param_1,int param_2,undefined4 param_3);
uint FUN_00410190(undefined4 *param_1,undefined4 *param_2);
void FUN_004102a4(int *param_1,char param_2);
undefined * FUN_004102c4(undefined **param_1,int param_2);
void FUN_004102f8(int *param_1);
void FUN_00410310(int *param_1,int param_2);
undefined4 FUN_00410370(void);
void FUN_00410374(undefined4 param_1,byte *param_2,undefined4 param_3);
void FUN_004103ac(undefined4 param_1,int **param_2,undefined4 param_3);
undefined ** FUN_00410400(undefined **param_1);
void FUN_00410418(undefined4 *param_1);
undefined4 FUN_00410420(undefined4 *param_1,int param_2);
int FUN_0041047c(int param_1,int param_2);
void FUN_0041049c(undefined **param_1,int param_2,int param_3);
void FUN_00410508(undefined4 *param_1);
void FUN_00410514(undefined **param_1,int param_2,int param_3);
void FUN_0041056c(int *param_1,int param_2,int param_3);
int FUN_004105b8(int *param_1,int param_2);
void FUN_004105d8(undefined4 *param_1,int param_2);
void FUN_00410614(int *param_1,int param_2);
int * FUN_00410688(int *param_1,char param_2,undefined4 param_3);
void FUN_00410758(int param_1,int param_2);
undefined4 FUN_004107e0(int param_1);
void FUN_004107f4(int param_1,int param_2);
void FUN_00410844(int param_1);
void FUN_00410880(void);
int FUN_00410898(int param_1,int param_2);
void FUN_004108a4(int param_1,int param_2);
void FUN_00410948(int param_1,uint param_2,char param_3);
uint FUN_00410974(int param_1,uint param_2);
int FUN_0041098c(int param_1);
void FUN_00410a04(int *param_1,char param_2);
void FUN_00410a30(int *param_1,undefined **param_2);
void FUN_00410a44(int *param_1,int *param_2);
void FUN_00410b14(int *param_1,int *param_2);
void FUN_00410b1c(void);
int * FUN_00410bd4(int *param_1,char param_2,int *param_3);
void FUN_00410c0c(int *param_1,char param_2);
void FUN_00410c3c(int param_1,char param_2);
int FUN_00410c60(int param_1);
void FUN_00410c78(int *param_1,int *param_2);
void FUN_00410ca0(int *param_1,byte **param_2);
void FUN_00410d58(int *param_1,int *param_2,undefined4 param_3);
void FUN_00410d88(int param_1,int param_2);
int * FUN_00410db8(int *param_1,char param_2,int param_3);
void FUN_00410e3c(int param_1);
void FUN_00410e48(int *param_1,undefined **param_2);
void FUN_00410ee4(int *param_1);
void FUN_00410ef4(int *param_1);
void FUN_00410f78(int param_1,undefined4 param_2,int param_3,undefined4 param_4);
undefined4 FUN_00410f98(int param_1);
void FUN_00410fa0(int param_1,int param_2);
void FUN_00410fb4(int *param_1,int *param_2);
void FUN_0041107c(int *param_1,int *param_2);
void FUN_00411198(int *param_1,int **param_2);
void FUN_00411230(int *param_1,undefined4 param_2,undefined4 param_3);
void FUN_00411294(int *param_1,int *param_2);
void FUN_004112f0(int *param_1,int param_2,undefined4 param_3);
int * FUN_00411324(int *param_1,char param_2,int param_3,int param_4);
void FUN_0041136c(int *param_1,char param_2);
void FUN_0041150c(int *param_1);
byte FUN_00411524(undefined param_1,undefined param_2,undefined param_3,int param_4);
void FUN_004115c8(int *param_1);
void FUN_004115dc(int *param_1,int *param_2);
undefined4 FUN_00411684(void);
void FUN_00411688(undefined4 param_1,byte *param_2,undefined4 param_3);
void FUN_004116c0(undefined4 param_1,int **param_2,undefined4 param_3);
void FUN_0041180c(int *param_1);
void FUN_00411948(int *param_1,undefined *param_2);
void FUN_004119c8(int *param_1,undefined *param_2);
int FUN_00411a8c(int *param_1,int param_2);
void FUN_00411ac0(int *param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4);
void FUN_00411b44(int *param_1,int *param_2);
void FUN_00411bf0(int *param_1,int param_2,int param_3);
void FUN_00411ca0(int *param_1,undefined4 param_2,undefined4 param_3);
void FUN_00411d84(int *param_1,undefined *param_2,undefined4 param_3);
void FUN_00411e3c(int param_1,int *param_2);
void FUN_00411ec0(int *param_1,undefined4 *param_2);
void FUN_00411f84(int *param_1,undefined *param_2,int param_3);
void FUN_004120ac(int *param_1,char param_2);
int FUN_00412108(int *param_1,undefined4 *param_2,int param_3);
void FUN_004121d0(int *param_1,int param_2);
void FUN_00412234(int *param_1,int param_2,int param_3);
void FUN_0041228c(int param_1,int param_2,int param_3);
uint FUN_004122b0(int param_1,undefined *param_2,uint *param_3);
void FUN_0041237c(int *param_1);
void FUN_004123e8(int *param_1,int param_2,undefined4 *param_3);
void FUN_00412430(int *param_1,int param_2,undefined4 *param_3);
void FUN_00412498(int *param_1,int param_2,undefined4 *param_3);
void FUN_0041252c(int param_1,uint param_2,uint param_3,undefined *param_4);
void FUN_004125dc(int *param_1,char param_2);
void FUN_00412664(int *param_1);
void FUN_00412674(int *param_1,undefined4 param_2);
undefined4 FUN_00412680(int *param_1);
void FUN_004126b8(int *param_1,undefined4 param_2,int param_3);
void FUN_004126f0(int *param_1,undefined4 param_2,int param_3);
void FUN_00412728(int *param_1,int *param_2,int param_3);
void FUN_004127dc(int param_1,int *param_2);
void FUN_0041283c(int param_1,int *param_2);
void FUN_00412844(int param_1,int *param_2,undefined4 param_3);
void FUN_004128a0(int *param_1,char param_2,int param_3);
void FUN_004128f0(int *param_1,undefined4 param_2);
int * FUN_00412910(int *param_1,char param_2,undefined *param_3,ushort param_4);
void FUN_004129f0(int param_1,undefined4 param_2,undefined4 param_3);
uint FUN_004129f8(int param_1,undefined4 *param_2,uint param_3);
void FUN_00412a80(int *param_1);
void FUN_00412a98(int *param_1,int param_2);
LPCVOID FUN_00412aec(int param_1,SIZE_T *param_2);
int * FUN_00412bc0(int *param_1,char param_2,HMODULE param_3,LPCSTR param_4,undefined *param_5);
void FUN_00412c18(undefined param_1,undefined param_2,undefined param_3,int param_4);
void FUN_00412c88(int param_1,HMODULE param_2,LPCSTR param_3,LPCSTR param_4);
int * FUN_00412d44(int *param_1,char param_2,int param_3,int param_4);
void FUN_00412d8c(int *param_1,char param_2);
void FUN_00412db4(int param_1,undefined4 param_2);
int * FUN_00412e2c(int *param_1,char param_2,int param_3,undefined4 *param_4,undefined4 *param_5,int param_6,int param_7);
bool FUN_00412e84(int param_1);
void FUN_00412ecc(int param_1,undefined4 *param_2);
void FUN_00412f94(int param_1,undefined4 param_2,undefined4 param_3,int param_4);
void FUN_00412fcc(int param_1,undefined4 param_2,undefined4 param_3,int param_4);
void FUN_00413014(void);
void FUN_004131d0(int param_1,char *param_2);
void FUN_0041327c(int param_1);
void FUN_00413300(int **param_1);
void FUN_00413318(void);
void FUN_00413324(void);
int FUN_00413330(char *param_1,byte *param_2);
void FUN_00413384(int param_1,undefined4 param_2,uint param_3);
void FUN_004133a8(int param_1,char *param_2,undefined param_3,undefined param_4,undefined param_5,code *param_6,undefined4 param_7);
void FUN_004133dc(int param_1,char *param_2,undefined param_3,undefined param_4,undefined param_5,code *param_6,undefined4 param_7);
uint FUN_004134b8(int param_1,undefined4 param_2,uint param_3);
int FUN_004134ec(int param_1,int *param_2,undefined4 *param_3);
void FUN_00413554(int param_1);
void FUN_004135d0(int *param_1);
void FUN_00413714(int param_1);
int FUN_00413750(int param_1);
void FUN_00413768(int param_1,undefined4 param_2,uint param_3);
void FUN_00413778(int param_1,undefined4 param_2,uint param_3);
void FUN_00413784(int param_1,undefined4 *param_2,uint param_3);
void FUN_004137d0(int param_1);
uint FUN_0041380c(int param_1,undefined4 param_2,uint param_3);
void FUN_00413820(int param_1,undefined4 param_2,uint param_3);
void FUN_004138a4(int param_1,int *param_2);
void FUN_004139d0(undefined4 param_1,undefined4 param_2,int param_3,int param_4);
void FUN_00413ae0(undefined4 param_1,undefined4 param_2,undefined4 param_3,int param_4);
void FUN_00413b80(undefined4 param_1,undefined4 param_2,int param_3,int param_4);
void FUN_00413c24(int *param_1,int *param_2);
void FUN_00413dfc(int *param_1,int *param_2,uint param_3);
void FUN_00413e6c(int *param_1,int *param_2,uint param_3);
void FUN_00413f3c(int param_1,undefined4 param_2,uint param_3);
void FUN_00413f7c(int param_1,undefined4 param_2,uint param_3);
void FUN_00413fbc(int param_1,undefined4 param_2,uint param_3);
void FUN_00414008(int param_1,undefined4 param_2,uint param_3);
void FUN_00414048(int param_1,int *param_2,uint param_3);
int FUN_00414148(int param_1,undefined4 param_2,uint param_3);
int FUN_004141b4(int param_1,undefined4 param_2,uint param_3);
void FUN_004141f8(int param_1,undefined4 param_2,uint param_3);
void FUN_00414200(int param_1,undefined4 param_2,uint param_3);
void FUN_00414208(int param_1,byte *param_2,int *param_3);
void FUN_00414348(undefined4 param_1,undefined4 param_2,uint param_3,int param_4);
void FUN_00414364(int *param_1,int *param_2);
void FUN_00414538(int *param_1,int **param_2,undefined4 param_3);
void FUN_00414580(int param_1,int param_2,undefined4 *param_3,int param_4);
void FUN_004145c0(undefined4 param_1,undefined4 param_2,undefined4 param_3,int param_4);
void FUN_004147b8(int *param_1,int *param_2,int **param_3);
void FUN_00414a50(undefined4 *param_1,byte **param_2);
void FUN_00414ac0(int *param_1,int *param_2);
void FUN_00414d64(int param_1,int param_2);
void FUN_00414e20(int param_1,undefined4 param_2,int param_3);
void FUN_00414e44(int param_1,int *param_2,uint param_3);
void FUN_00414e80(int param_1,int *param_2,uint param_3);
void FUN_00414ee0(int param_1,BSTR *param_2,uint param_3);
uint FUN_00414f28(int param_1,undefined4 param_2,uint param_3);
void FUN_00414f3c(int param_1,undefined4 param_2,uint param_3);
void FUN_00414f84(undefined4 param_1,undefined4 param_2,uint param_3,int param_4);
void FUN_00414fac(uint param_1,undefined4 param_2,undefined4 param_3,int param_4);
void FUN_00415000(undefined4 param_1,undefined4 param_2,uint param_3,int param_4);
void FUN_00415028(undefined4 param_1,undefined4 param_2,uint param_3,uint param_4);
void FUN_00415088(int param_1,undefined4 param_2,uint param_3);
void FUN_004151f0(int param_1,undefined4 param_2,uint param_3);
int FUN_004153d8(int param_1,char *param_2,int param_3);
int FUN_004154d4(int param_1);
void FUN_004154ec(int param_1,int param_2);
void FUN_0041553c(int param_1,undefined4 *param_2,uint param_3);
void FUN_00415588(int param_1,undefined4 param_2,undefined4 param_3,undefined *param_4,undefined4 param_5);
void FUN_00415610(int param_1);
void FUN_00415628(int param_1,char param_2,uint param_3);
void FUN_0041563c(int param_1,undefined4 param_2);
void FUN_0041568c(int param_1,int param_2,uint param_3);
int FUN_004156e4(char *param_1,undefined4 param_2,undefined4 param_3,int param_4);
void FUN_00415734(int param_1,int *param_2,undefined4 param_3);
void FUN_00415810(int param_1,int *param_2);
void FUN_00415b70(int param_1,int *param_2,undefined4 param_3);
void FUN_00415b98(int param_1,undefined4 param_2,uint param_3,undefined param_4);
void FUN_00415bbc(int param_1,undefined4 param_2,uint param_3,undefined param_4);
void FUN_00415be0(int param_1,undefined4 param_2,uint param_3,undefined param_4);
void FUN_00415c04(int param_1,undefined4 param_2,uint param_3,undefined param_4);
void FUN_00415c28(int param_1,char *param_2);
void FUN_00415cec(int param_1,int param_2,uint param_3);
void FUN_00415d60(int param_1,undefined4 param_2,uint param_3,uint param_4,int param_5);
void FUN_00415db8(int param_1,undefined4 param_2,uint param_3);
void FUN_00415dc0(int param_1,undefined4 param_2,uint param_3);
void FUN_00415dc8(int param_1,char param_2,uint param_3);
void FUN_00415e0c(undefined4 param_1,int *param_2);
undefined4 FUN_00415ed4(undefined param_1,undefined param_2,undefined param_3,int param_4);
void FUN_00415f20(undefined param_1,undefined param_2,undefined param_3,int param_4);
void FUN_00415f74(uint param_1,undefined4 param_2,undefined4 param_3,int param_4);
void FUN_00416008(int param_1,int param_2,undefined4 param_3,int param_4);
void FUN_00416074(int param_1,undefined4 param_2,undefined4 param_3,int param_4);
uint FUN_00416118(undefined param_1,undefined param_2,undefined param_3,int param_4);
void FUN_00416168(undefined param_1,undefined param_2,undefined param_3,int param_4);
uint FUN_0041623c(undefined param_1,undefined param_2,undefined param_3,uint param_4);
void FUN_00416294(undefined param_1,undefined param_2,undefined param_3,uint param_4);
uint FUN_004162e0(undefined param_1,undefined param_2,undefined param_3,uint param_4);
void FUN_00416330(undefined param_1,undefined param_2,undefined param_3,uint param_4);
void FUN_00416378(undefined param_1,undefined param_2,undefined param_3,int param_4);
void FUN_004163fc(undefined param_1,undefined param_2,undefined param_3,uint param_4);
uint FUN_00416468(undefined param_1,undefined param_2,undefined param_3,uint param_4);
void FUN_004164f8(int param_1,int *param_2,undefined4 param_3,int param_4);
void FUN_004165b4(undefined param_1,undefined param_2,undefined param_3,uint param_4);
undefined4 FUN_004167dc(undefined param_1,undefined param_2,undefined param_3,int param_4);
void FUN_00416860(undefined param_1,undefined param_2,undefined param_3,uint param_4);
void FUN_00416914(undefined param_1,undefined param_2,undefined param_3,int param_4);
void FUN_004169a0(undefined param_1,undefined param_2,undefined param_3,int param_4);
void FUN_00416c24(undefined4 param_1,undefined4 param_2,undefined4 *param_3);
void FUN_00416cdc(int param_1,undefined4 *param_2);
void FUN_00416d30(int param_1);
void FUN_00416d40(int param_1,undefined *param_2,uint param_3);
void FUN_00416d88(int param_1,undefined4 *param_2,uint param_3);
void FUN_00416de4(int param_1,undefined4 *param_2,uint param_3);
void FUN_00416e20(int param_1,byte param_2,uint param_3);
void FUN_00416e34(void);
LRESULT FUN_00416e50(undefined4 param_1,undefined4 param_2,undefined4 param_3,HWND param_4,UINT param_5,WPARAM param_6,int param_7);
void FUN_00416f4c(void);
void FUN_00416fd4(void);
void FUN_0041702c(void);
int * FUN_004170f0(int *param_1,char param_2,undefined4 param_3);
void FUN_004171d8(int param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4,undefined4 param_5);
void FUN_00417214(int param_1);
void FUN_0041722c(int param_1);
DWORD FUN_00417234(int param_1);
int * FUN_00417298(int *param_1,char param_2,int *param_3);
void FUN_004172e4(int *param_1,char param_2);
void FUN_00417378(int param_1,int param_2,undefined4 param_3);
void FUN_0041740c(int param_1,int param_2,undefined4 param_3);
void FUN_00417438(int param_1,int param_2);
void FUN_00417460(int *param_1,int *param_2,undefined4 param_3);
void FUN_004174b8(int *param_1,int param_2);
void FUN_004174f0(int *param_1);
void FUN_00417548(int param_1);
void FUN_00417584(int param_1,int param_2);
void FUN_004175a8(int param_1,int param_2);
void FUN_004175c4(int param_1,int param_2,byte param_3);
void FUN_00417620(int param_1,int *param_2,uint param_3);
undefined4 FUN_004176a8(void);
void FUN_004176ac(void);
undefined4 FUN_004176d8(void);
void FUN_004176f8(int param_1);
void FUN_00417704(int *param_1,int *param_2,uint param_3);
void FUN_00417714(int param_1,int param_2,char *param_3,char *param_4);
int FUN_004177ac(int param_1,char *param_2);
void FUN_004177fc(int *param_1,uint *param_2);
void FUN_00417888(int param_1,undefined4 *param_2);
void FUN_0041789c(int param_1,int param_2);
undefined4 FUN_004178c8(int param_1);
void FUN_004178d8(int param_1,int param_2);
void FUN_0041792c(int param_1,undefined4 param_2,char param_3);
void FUN_0041797c(int param_1,char param_2);
undefined4 FUN_004179c4(undefined4 param_1,int *param_2);
void FUN_00417a2c(void);
undefined4 FUN_00417a34(undefined param_1,undefined param_2,undefined param_3,int *param_4,int *param_5,int **param_6);
undefined ** FUN_00417a74(undefined **param_1,char param_2,undefined4 param_3);
undefined FUN_00417b44(void);
void FUN_00417b48(void);
int * FUN_00417b5c(int *param_1,char param_2,int *param_3);
void FUN_00417ba0(int *param_1,char param_2);
undefined4 FUN_00417bf8(int param_1);
undefined4 FUN_00417c14(int param_1);
void FUN_00417c98(int param_1,int param_2);
void FUN_00417ca4(int param_1,int param_2);
int * FUN_00417ce4(int *param_1,char param_2,int param_3,undefined param_4);
undefined4 FUN_00417d64(undefined param_1,undefined param_2,undefined param_3,int param_4,int param_5,undefined4 param_6,undefined4 *param_7);
undefined4 FUN_00418110(void);
undefined4 FUN_0041811c(void);
undefined4 FUN_00418128(undefined param_1,undefined param_2,undefined param_3,int param_4,int param_5);
void FUN_004181c0(void);
void FUN_004191c4(HGDIOBJ param_1);
ushort FUN_00419238(byte *param_1,int param_2);
int * FUN_0041924c(int *param_1,char param_2,undefined4 param_3);
void FUN_004192ac(int param_1);
void FUN_004192b8(int param_1);
void FUN_004192c4(int param_1,int *param_2);
void FUN_004193a8(int param_1,undefined4 *param_2);
void FUN_00419458(int param_1,int *param_2,int *param_3);
void FUN_004194d0(int param_1,int *param_2,undefined4 *param_3);
void FUN_0041953c(int param_1);
void FUN_004195a8(void);
void FUN_004199ac(uint param_1);
void FUN_004199f0(int param_1);
void FUN_00419a00(int param_1);
void FUN_00419be4(HANDLE param_1,HANDLE *param_2);
int * FUN_00419c98(int *param_1,char param_2,undefined4 param_3);
void FUN_00419e04(int param_1,undefined4 *param_2);
void FUN_00419e1c(int *param_1,int *param_2);
void FUN_00419e6c(int *param_1,int param_2,undefined4 param_3);
void FUN_00419e80(int param_1);
void FUN_0041a028(int *param_1,HANDLE param_2);
undefined4 FUN_0041a04c(int param_1);
void FUN_0041a054(int *param_1,undefined4 param_2);
void FUN_0041a07c(int param_1,int *param_2);
void FUN_0041a094(int *param_1,undefined4 *param_2);
int FUN_0041a0f0(int param_1);
void FUN_0041a10c(int *param_1,int param_2);
uint FUN_0041a12c(int param_1,uint param_2);
void FUN_0041a138(int *param_1,undefined param_2);
uint FUN_0041a164(int param_1);
int * FUN_0041a1c4(int *param_1,char param_2,undefined4 param_3);
void FUN_0041a2e8(int param_1,undefined4 *param_2);
void FUN_0041a300(int *param_1,int *param_2);
void FUN_0041a358(int *param_1,undefined4 param_2);
undefined4 FUN_0041a380(int param_1);
void FUN_0041a418(int *param_1,undefined4 param_2,undefined4 param_3);
void FUN_0041a434(int *param_1,undefined param_2);
void FUN_0041a464(int *param_1,int param_2);
int * FUN_0041a490(int *param_1,char param_2,undefined4 param_3);
void FUN_0041a5a0(int param_1,undefined4 *param_2);
void FUN_0041a5c0(int *param_1,int *param_2);
void FUN_0041a610(int *param_1,undefined4 param_2);
undefined4 FUN_0041a634(int param_1);
void FUN_0041a63c(int *param_1,undefined4 param_2);
undefined4 FUN_0041a670(int param_1);
uint FUN_0041a750(int param_1);
void FUN_0041a758(int *param_1,char param_2);
int * FUN_0041a78c(int *param_1,char param_2,undefined4 param_3);
void FUN_0041a850(int *param_1,char param_2);
void FUN_0041a8ac(int *param_1,int *param_2,int *param_3,uint param_4,int *param_5);
void FUN_0041ab6c(int *param_1,int *param_2,int *param_3,int *param_4);
void FUN_0041abf4(int *param_1,int param_2,int param_3,int *param_4);
void FUN_0041aca0(int *param_1,RECT *param_2);
void FUN_0041acdc(int *param_1,RECT *param_2);
void FUN_0041ad18(int *param_1,int param_2,int param_3);
void FUN_0041ad50(int param_1);
void FUN_0041ad78(int *param_1,int param_2,int param_3);
void FUN_0041ada4(int *param_1,POINT *param_2,int param_3);
void FUN_0041addc(int *param_1,int param_2,int param_3,int param_4,int param_5);
void FUN_0041ae24(int *param_1,undefined4 param_2,int *param_3);
undefined4 FUN_0041ae60(int *param_1);
void FUN_0041ae8c(int *param_1,int param_2,int param_3,undefined *param_4);
void FUN_0041af18(int *param_1,undefined *param_2,LPSIZE param_3);
LONG FUN_0041af5c(int *param_1,undefined *param_2);
LONG FUN_0041af78(int *param_1,undefined *param_2);
void FUN_0041af98(int param_1,undefined4 param_2,uint param_3);
void FUN_0041aff4(int param_1);
void FUN_0041b01c(int param_1);
void FUN_0041b038(int param_1);
void FUN_0041b044(int *param_1,LPPOINT param_2);
void FUN_0041b068(int *param_1,int *param_2);
void FUN_0041b088(int *param_1,int param_2,int param_3);
void FUN_0041b0b4(int *param_1,int param_2,int param_3,uint param_4);
int FUN_0041b0fc(int *param_1);
void FUN_0041b11c(int param_1);
void FUN_0041b178(void);
void FUN_0041b17c(int *param_1,int param_2);
void FUN_0041b1d0(int *param_1,byte param_2);
void FUN_0041b26c(int param_1);
void FUN_0041b298(int param_1);
void FUN_0041b2c8(int param_1);
void FUN_0041b3a4(int **param_1);
void FUN_0041b3bc(int **param_1);
void FUN_0041b3d4(void);
void FUN_0041b3e0(void);
void FUN_0041b3ec(void);
void FUN_0041b3f8(void);
void FUN_0041b44c(void);
int FUN_0041b4f4(int param_1);
void FUN_0041b504(HANDLE param_1,int *param_2,char param_3);
int FUN_0041b664(short param_1);
int FUN_0041b684(int param_1,int param_2,int param_3);
void FUN_0041b698(HDC param_1,int param_2,int param_3,int param_4,int param_5,HDC param_6,int param_7,int param_8,int param_9,int param_10,HDC param_11,int param_12,int param_13);
void FUN_0041b92c(int param_1);
void FUN_0041b964(int param_1,int *param_2);
void FUN_0041b9dc(int param_1,int param_2);
void FUN_0041ba34(undefined4 *param_1);
uint FUN_0041bb4c(uint param_1);
HPALETTE FUN_0041bbe4(HGDIOBJ param_1,undefined4 *param_2,int param_3);
UINT FUN_0041bc88(HPALETTE param_1,LPPALETTEENTRY param_2,int param_3);
void FUN_0041bcdc(BITMAPINFOHEADER *param_1,undefined4 *param_2,undefined4 param_3,int *param_4);
int FUN_0041be98(int param_1);
undefined4 FUN_0041bea4(byte *param_1,byte *param_2,undefined4 param_3,int param_4);
void FUN_0041bf34(int *param_1,undefined4 param_2,int param_3,uint *param_4,uint *param_5);
ushort FUN_0041c23c(ushort *param_1);
void FUN_0041c254(HANDLE param_1,uint *param_2,uint param_3);
void FUN_0041c338(HANDLE param_1,int *param_2,undefined4 *param_3,uint param_4);
void FUN_0041c39c(HANDLE param_1,int *param_2,undefined4 *param_3);
void FUN_0041c3a4(HBITMAP param_1,HPALETTE param_2,LPBITMAPINFO param_3,uint param_4,LPVOID param_5);
void FUN_0041c454(HBITMAP param_1,HPALETTE param_2,LPBITMAPINFO param_3,LPVOID param_4);
void FUN_0041c468(void);
void FUN_0041c46c(int param_1);
void FUN_0041c478(int *param_1,HICON param_2,char param_3);
int * FUN_0041c674(int *param_1,char param_2,undefined4 param_3);
void FUN_0041c6ac(int param_1);
uint FUN_0041c6c4(undefined param_1,undefined param_2,undefined param_3,int param_4);
void FUN_0041c71c(int *param_1,int *param_2);
void FUN_0041c908(int param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4,undefined4 param_5,byte param_6,byte param_7);
void FUN_0041c93c(int *param_1,undefined *param_2,undefined4 param_3);
void FUN_0041ca50(undefined **param_1,char param_2);
void FUN_0041cbd0(undefined **param_1,undefined *param_2,undefined4 *param_3,undefined4 param_4,undefined4 param_5);
void FUN_0041cc64(undefined4 *param_1,uint *param_2);
int * FUN_0041cd54(int *param_1,char param_2,undefined4 param_3);
void FUN_0041ce00(int param_1,uint param_2,int param_3);
undefined4 FUN_0041ce68(int param_1,short param_2);
int FUN_0041cea4(void);
int * FUN_0041cec4(undefined4 param_1,undefined4 param_2,undefined4 param_3);
int * FUN_0041cee4(int *param_1,char param_2,undefined4 param_3);
void FUN_0041cf88(int *param_1,int param_2);
int FUN_0041cfec(int *param_1);
int FUN_0041d004(int *param_1);
void FUN_0041d01c(int *param_1,undefined4 *param_2);
void FUN_0041d0cc(int *param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4);
void FUN_0041d190(int param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4);
uint FUN_0041d1bc(undefined4 param_1,undefined4 param_2,undefined4 param_3);
void FUN_0041d230(int param_1);
undefined4 FUN_0041d4b8(int param_1);
undefined4 FUN_0041d4d0(int param_1);
void FUN_0041d634(int *param_1,int *param_2,LONG *param_3);
void FUN_0041d878(int param_1);
void FUN_0041d8a0(int *param_1,int *param_2,int param_3);
void FUN_0041d90c(int param_1,int *param_2);
void FUN_0041d9dc(int param_1,int *param_2,int param_3);
void FUN_0041dc78(int *param_1,int param_2,undefined4 param_3);
void FUN_0041dcb4(int *param_1,int param_2,undefined4 param_3);
undefined4 FUN_0041dd68(undefined4 param_1,int *param_2);
void FUN_0041ddc8(int param_1,undefined4 param_2,undefined4 param_3);
void FUN_0041de4c(int param_1,int *param_2);
void FUN_0041ded0(int param_1,int *param_2);
void FUN_0041df5c(int param_1,int *param_2);
void FUN_0041e0a4(int *param_1);
void FUN_0041e128(int param_1,undefined2 *param_2,HENHMETAFILE *param_3,undefined4 *param_4);
void FUN_0041e1f8(void);
void FUN_0041e2a4(int param_1);
int * FUN_0041e320(int *param_1,char param_2,int param_3);
void FUN_0041e388(int *param_1);
void FUN_0041e428(int *param_1);
void FUN_0041e514(int param_1);
void FUN_0041e518(undefined **param_1);
void FUN_0041e5e0(HGDIOBJ param_1,HPALETTE param_2,int param_3);
void FUN_0041e69c(int param_1);
HPALETTE FUN_0041e6e8(HBITMAP param_1,HPALETTE param_2,HPALETTE param_3,int param_4,int param_5);
HPALETTE FUN_0041ed44(HPALETTE param_1);
BOOL FUN_0041eda8(HPALETTE param_1,HPALETTE param_2,COLORREF param_3);
int * FUN_0041efb4(int *param_1,char param_2,undefined4 param_3);
void FUN_0041f058(int *param_1,undefined **param_2);
void FUN_0041f148(int param_1,HBITMAP param_2,HPALETTE param_3,undefined4 *param_4);
void FUN_0041f208(int param_1);
void FUN_0041f238(int param_1);
void FUN_0041f4a4(int param_1);
int FUN_0041f520(int *param_1);
undefined4 FUN_0041f560(int param_1);
undefined4 FUN_0041f584(int param_1);
undefined4 FUN_0041f5d4(int param_1);
uint FUN_0041f604(int *param_1);
void FUN_0041f654(int param_1);
void FUN_0041f6c8(int param_1);
void FUN_0041f6d8(int param_1);
void FUN_0041f6e8(int *param_1,uint param_2);
void FUN_0041f7c8(int *param_1);
void FUN_0041f828(int param_1);
void FUN_0041f8e0(int *param_1,short param_2,HBITMAP param_3,HPALETTE param_4);
void FUN_0041f988(int param_1,undefined4 param_2,undefined4 param_3,int *param_4,undefined param_5,undefined4 *param_6);
void FUN_0041fab0(undefined4 param_1,int *param_2,int param_3);
void FUN_0041ffc0(int param_1,int *param_2,int param_3);
void FUN_00420030(int *param_1,HANDLE param_2);
void FUN_0042022c(int *param_1,int param_2);
void FUN_00420280(int *param_1,byte param_2);
void FUN_004203d4(int *param_1,int param_2);
void FUN_00420480(int *param_1,int *param_2,char param_3);
int FUN_0042071c(int param_1);
void FUN_00420758(int param_1,undefined2 *param_2,HPALETTE *param_3,HPALETTE *param_4);
int * FUN_00420840(int *param_1,char param_2,undefined4 param_3);
undefined4 FUN_0042097c(int param_1);
void FUN_004209b8(int param_1);
void FUN_00420a30(int param_1,undefined4 param_2,undefined4 param_3);
void FUN_00420b9c(int param_1,undefined4 param_2,undefined4 param_3);
void FUN_00420c10(int *param_1,undefined4 param_2);
void FUN_00420cb0(void);
BYTE FUN_00420ce8(void);
void FUN_00420d2c(void);
int * FUN_00420dfc(int *param_1,char param_2,undefined4 param_3);
void FUN_00420e60(int param_1);
void FUN_00420e6c(int param_1);
void FUN_00420e78(int param_1,int param_2,uint param_3);
int * FUN_00420f2c(undefined4 param_1,undefined4 param_2,uint param_3);
void FUN_0042102c(int param_1);
undefined4 FUN_004210a4(uint param_1,uint param_2);
int * FUN_00421384(int *param_1,char param_2,undefined4 param_3);
void __stdcall InitCommonControls(void);
void FUN_00421478(void);
int FUN_004214d8(void);
HIMAGELIST __stdcall ImageList_Create(int cx,int cy,UINT flags,int cInitial,int cGrow);
BOOL __stdcall ImageList_Destroy(HIMAGELIST himl);
int __stdcall ImageList_GetImageCount(HIMAGELIST himl);
int __stdcall ImageList_Add(HIMAGELIST himl,HBITMAP hbmImage,HBITMAP hbmMask);
int __stdcall ImageList_ReplaceIcon(HIMAGELIST himl,int i,HICON hicon);
COLORREF __stdcall ImageList_SetBkColor(HIMAGELIST himl,COLORREF clrBk);
COLORREF __stdcall ImageList_GetBkColor(HIMAGELIST himl);
void FUN_00421544(HIMAGELIST param_1,HICON param_2);
int FUN_00421550(int param_1);
BOOL __stdcall ImageList_Draw(HIMAGELIST himl,int i,HDC hdcDst,int x,int y,UINT fStyle);
BOOL __stdcall ImageList_DrawEx(HIMAGELIST himl,int i,HDC hdcDst,int x,int y,int dx,int dy,COLORREF rgbBk,COLORREF rgbFg,UINT fStyle);
BOOL __stdcall ImageList_Remove(HIMAGELIST himl,int i);
BOOL __stdcall ImageList_BeginDrag(HIMAGELIST himlTrack,int iTrack,int dxHotspot,int dyHotspot);
void __stdcall ImageList_EndDrag(void);
BOOL __stdcall ImageList_DragEnter(HWND hwndLock,int x,int y);
BOOL __stdcall ImageList_DragLeave(HWND hwndLock);
BOOL __stdcall ImageList_DragMove(int x,int y);
BOOL __stdcall ImageList_SetDragCursorImage(HIMAGELIST himlDrag,int iDrag,int dxHotspot,int dyHotspot);
BOOL __stdcall ImageList_DragShowNolock(BOOL fShow);
HIMAGELIST __stdcall ImageList_GetDragImage(POINT *ppt,POINT *pptHotspot);
HIMAGELIST __stdcall ImageList_Read(IStream *pstm);
BOOL __stdcall ImageList_Write(HIMAGELIST himl,IStream *pstm);
BOOL __stdcall ImageList_GetIconSize(HIMAGELIST himl,int *cx,int *cy);
BOOL __stdcall ImageList_SetIconSize(HIMAGELIST himl,int cx,int cy);
void FUN_004215cc(HWND param_1,LPARAM param_2);
void FUN_004215e4(HWND param_1,LPARAM param_2,WPARAM param_3);
void FUN_00421600(HWND param_1);
int FUN_00421610(int param_1);
void FUN_00421614(HWND param_1,LPARAM param_2);
void FUN_0042162c(HWND param_1,LPARAM param_2);
void FUN_00421644(HWND param_1,LPARAM param_2);
void FUN_0042165c(HWND param_1,WPARAM param_2);
void FUN_00421674(HWND param_1);
void FUN_00421688(HWND param_1,WPARAM param_2,uint param_3);
void FUN_004216ac(HWND param_1,WPARAM param_2,LPARAM param_3);
void FUN_004216bc(HWND param_1,WPARAM param_2,undefined4 *param_3,undefined4 param_4);
void FUN_004216f8(HWND param_1,LPARAM param_2);
void FUN_00421708(HWND param_1,WPARAM param_2,LPARAM param_3);
void FUN_00421724(HWND param_1,WPARAM param_2);
void FUN_0042173c(HWND param_1);
void FUN_00421750(HWND param_1,WPARAM param_2,LPARAM param_3);
void FUN_0042176c(HWND param_1,WPARAM param_2,LPARAM param_3);
void FUN_0042177c(HWND param_1,WPARAM param_2);
void FUN_00421794(HWND param_1,WPARAM param_2);
void FUN_004217ac(HWND param_1,WPARAM param_2,uint param_3);
void FUN_004217d0(HWND param_1,WPARAM param_2,LPARAM param_3);
void FUN_004217ec(HWND param_1,LPARAM param_2);
void FUN_00421804(HWND param_1,LPARAM param_2);
void FUN_0042181c(HWND param_1);
void FUN_0042182c(HWND param_1,LPARAM param_2);
int FUN_00421844(HWND param_1,WPARAM param_2);
void FUN_00421864(HWND param_1,WPARAM param_2,undefined4 param_3,undefined4 param_4);
void FUN_00421894(HWND param_1,WPARAM param_2,LPARAM param_3);
int FUN_004218a4(HWND param_1,WPARAM param_2);
void FUN_004218c4(HWND param_1,WPARAM param_2,uint param_3);
void FUN_004218f0(HWND param_1,WPARAM param_2,undefined4 param_3,undefined4 param_4);
void FUN_00421920(HWND param_1,WPARAM param_2);
void FUN_00421930(HWND param_1,WPARAM param_2,LPARAM param_3);
void FUN_00421940(HWND param_1,LPARAM param_2,WPARAM param_3);
void FUN_0042195c(HWND param_1);
void FUN_0042196c(HWND param_1,LPARAM param_2);
void FUN_00421984(HWND param_1,WPARAM param_2,LPARAM param_3);
void FUN_004219a0(HWND param_1,WPARAM param_2,LPARAM param_3);
void FUN_004219bc(HWND param_1,WPARAM param_2,LPARAM param_3);
void FUN_004219f8(HWND param_1,LPARAM param_2);
void FUN_00421a10(HWND param_1,LPARAM param_2);
void FUN_00421a28(HWND param_1);
void FUN_00421a40(HWND param_1,LPARAM param_2,WPARAM param_3);
void FUN_00421a5c(HWND param_1,undefined4 param_2,undefined4 *param_3,WPARAM param_4);
void FUN_00421a80(HWND param_1);
void FUN_00421a90(HWND param_1);
void FUN_00421aa0(HWND param_1,WPARAM param_2);
void FUN_00421ab8(HWND param_1,LPARAM param_2,WPARAM param_3);
void FUN_00421ad4(HWND param_1,LPARAM param_2,WPARAM param_3);
void FUN_00421af0(HWND param_1,LPARAM param_2);
void FUN_00421afc(HWND param_1,LPARAM param_2);
void FUN_00421b08(HWND param_1,LPARAM param_2);
void FUN_00421b14(HWND param_1,LPARAM param_2);
void FUN_00421b20(HWND param_1);
void FUN_00421b30(HWND param_1);
void FUN_00421b40(HWND param_1);
void FUN_00421b50(HWND param_1);
void FUN_00421b5c(HWND param_1,LPARAM param_2,WPARAM param_3);
void FUN_00421b78(HWND param_1,LPARAM param_2);
void FUN_00421b84(HWND param_1,LPARAM param_2);
void FUN_00421b90(HWND param_1,LPARAM param_2);
void FUN_00421b9c(HWND param_1,LPARAM param_2);
void FUN_00421bb4(HWND param_1,LPARAM param_2);
void FUN_00421bcc(HWND param_1);
void FUN_00421be0(HWND param_1,LPARAM param_2);
void FUN_00421bf8(HWND param_1,LPARAM param_2);
void FUN_00421c10(HWND param_1,LPARAM param_2,WPARAM param_3);
void FUN_00421c2c(HWND param_1,LPARAM param_2);
void FUN_00421c44(HWND param_1,LPARAM param_2);
void FUN_00421c5c(void);
void FUN_00421c94(byte param_1,undefined4 param_2,undefined *param_3);
undefined4 FUN_00421e04(undefined param_1,undefined param_2,undefined param_3,int *param_4,uint param_5);
void FUN_0042237c(void);
void FUN_00422428(void);
int FUN_00422460(int param_1,int param_2);
void FUN_00422468(void);
int FUN_0042251c(undefined param_1,undefined param_2,undefined param_3,undefined4 param_4,undefined4 param_5,undefined4 param_6,undefined4 param_7);
int FUN_00422550(undefined param_1,undefined param_2,undefined param_3,undefined4 param_4);
void FUN_00422578(void);
undefined4 FUN_00426924(int param_1);
void FUN_00426bf4(int *param_1);
void FUN_00426e84(int *param_1);
void FUN_00426e98(int *param_1,undefined4 param_2);
int * FUN_00426ec8(int *param_1,char param_2,int *param_3);
void FUN_004271d4(int *param_1);
uint FUN_004272d0(uint param_1);
void FUN_00427358(int *param_1,undefined4 param_2,undefined4 param_3);
void FUN_00427380(int *param_1,int param_2,byte param_3);
void FUN_004273c8(int *param_1);
int * FUN_00427480(int *param_1,char param_2,int *param_3);
void FUN_00427548(int *param_1,char param_2);
void FUN_0042755c(int *param_1,char param_2);
uint FUN_004275ec(int *param_1);
void FUN_00427624(int *param_1,byte param_2);
void FUN_004277f8(int *param_1);
void FUN_00427814(int *param_1);
void FUN_00427830(int *param_1,undefined4 *param_2,int param_3);
void FUN_004278cc(int *param_1,int *param_2);
void FUN_00427968(int *param_1,int *param_2);
void FUN_00427b54(int *param_1);
void FUN_00427b90(int *param_1);
void FUN_00427c38(int param_1);
void FUN_00427d08(int *param_1);
void FUN_00427d8c(int *param_1);
LRESULT FUN_00427dc4(int param_1);
void FUN_00427e28(int param_1,WPARAM param_2,int *param_3);
void FUN_00427e6c(int param_1,WPARAM param_2,undefined *param_3);
void FUN_00427ee0(int param_1,WPARAM param_2,undefined4 *param_3);
void FUN_004280f0(int param_1,undefined4 *param_2);
void FUN_00428278(int *param_1,int *param_2);
void FUN_004282dc(int param_1,LPARAM *param_2);
void FUN_00428414(int *param_1);
void FUN_004284d8(int param_1);
void FUN_004284f4(int param_1,WPARAM param_2,int *param_3);
void FUN_004286f8(int param_1);
void FUN_00428934(int param_1);
bool FUN_00428960(int *param_1);
void FUN_00428984(int *param_1,byte param_2);
void FUN_004289cc(int *param_1);
void FUN_004289e8(int *param_1,WPARAM param_2);
void FUN_00428a68(int param_1,char param_2);
void FUN_00428cb4(int *param_1);
void FUN_0042958c(int param_1,undefined4 param_2,LONG *param_3,ushort param_4);
void FUN_00429684(int *param_1,int param_2);
void FUN_00429754(int *param_1,int param_2);
int * FUN_004298f0(int *param_1,char param_2,int *param_3);
undefined4 FUN_00429998(int param_1);
int * FUN_00429a34(int *param_1,char param_2,int *param_3);
void FUN_00429ac0(int *param_1,char param_2);
void FUN_00429b14(int *param_1,undefined param_2);
void FUN_00429b48(int *param_1,int *param_2);
void FUN_00429bb0(int *param_1,int param_2);
void FUN_00429ca4(int *param_1,int param_2);
void FUN_00429e20(int *param_1,char param_2);
void FUN_00429e70(int *param_1,int *param_2);
void FUN_0042a080(int param_1);
void FUN_0042a0c4(int param_1);
void FUN_0042a0e0(int param_1);
void FUN_0042a10c(int param_1);
void FUN_0042a188(int param_1,int *param_2);
void FUN_0042a238(int param_1,int *param_2);
void FUN_0042a36c(int param_1,int param_2);
void FUN_0042a4c0(int param_1,uint param_2);
void FUN_0042a514(undefined4 param_1,undefined4 param_2,uint param_3,int param_4);
undefined4 FUN_0042a594(undefined4 param_1,ushort param_2);
int FUN_0042a5cc(undefined4 param_1,undefined4 param_2,undefined4 param_3);
void FUN_0042a5ec(void);
int * FUN_0042a768(int *param_1,char param_2,int *param_3);
void FUN_0042c670(char *param_1);
undefined4 FUN_0042c684(undefined param_1,undefined param_2,undefined param_3,HWND param_4,undefined4 param_5,undefined4 param_6,undefined4 param_7);
HANDLE FUN_0042c73c(HWND param_1);
LRESULT FUN_0042c758(UINT param_1,WPARAM param_2,LPARAM param_3);
void FUN_0042c93c(undefined4 *param_1,int *param_2);
void FUN_0042c980(undefined4 *param_1,int *param_2);
HANDLE FUN_0042c9c4(void);
void FUN_0042c9ec(int *param_1);
uint FUN_0042ca98(undefined4 *param_1,int param_2,int *param_3);
HWND FUN_0042cacc(undefined param_1,undefined param_2,undefined param_3,int param_4);
void FUN_0042caf4(undefined **param_1,undefined4 param_2);
int FUN_0042cb84(undefined4 *param_1,undefined4 param_2,int param_3);
void FUN_0042cbe8(int param_1,int param_2);
HWND FUN_0042cc28(void);
void FUN_0042cc40(void);
void FUN_0042cc70(undefined4 param_1,HWND param_2);
undefined2 FUN_0042cd78(undefined4 param_1,char param_2);
void FUN_0042cda0(int *param_1,char param_2,int param_3);
void FUN_0042cdc4(int param_1,int *param_2);
void FUN_0042ce14(int *param_1,undefined4 param_2,undefined4 param_3,char param_4,undefined4 param_5);
int * FUN_0042ceac(int *param_1,char param_2,int param_3);
uint FUN_0042cfc4(uint param_1,uint param_2);
void FUN_0042cfe8(int param_1,undefined4 *param_2);
uint FUN_0042d110(int *param_1,undefined4 param_2,undefined4 param_3,int param_4);
bool FUN_0042d2a8(undefined param_1,undefined param_2,undefined param_3,int param_4);
int * FUN_0042d2ec(undefined4 *param_1,int *param_2);
void FUN_0042d438(int param_1,char param_2,undefined4 param_3);
LRESULT FUN_0042d498(HWND param_1,uint param_2,undefined4 param_3,undefined4 *param_4,undefined4 param_5);
undefined4 FUN_0042d4f0(HWND param_1);
HWND FUN_0042d514(POINT *param_1);
int * FUN_0042d540(POINT *param_1,HWND *param_2,char param_3,int *param_4);
bool FUN_0042d590(uint param_1);
undefined4 FUN_0042d5cc(void);
void FUN_0042d660(POINT *param_1);
void FUN_0042d934(int *param_1,char param_2,undefined4 param_3);
void FUN_0042daa4(int *param_1,char param_2,undefined4 param_3);
uint FUN_0042dc6c(undefined param_1,undefined param_2,undefined param_3,int param_4);
void FUN_0042dcdc(char param_1);
void FUN_0042df3c(void);
HANDLE FUN_0042df54(POINT *param_1);
int * FUN_0042df88(POINT *param_1,undefined4 param_2);
void FUN_0042dfd0(undefined **param_1,int param_2,undefined4 param_3);
void FUN_0042dff8(int **param_1,int param_2);
void FUN_0042e018(HDC param_1,int param_2,int param_3);
void FUN_0042e048(void);
void FUN_0042e104(void);
void FUN_0042e1dc(int *param_1);
void FUN_0042e284(int *param_1);
void FUN_0042e2b8(int *param_1,int param_2);
void FUN_0042e2d0(int param_1);
int * FUN_0042e2fc(int *param_1,char param_2,int param_3);
void FUN_0042e440(int param_1,int *param_2);
undefined4 FUN_0042e5ec(int param_1);
undefined4 FUN_0042e620(int param_1);
undefined4 FUN_0042e650(int param_1);
int * FUN_0042e728(int *param_1,char param_2,int *param_3);
void FUN_0042e7f8(int *param_1,char param_2);
uint FUN_0042e8f0(HPALETTE param_1,undefined4 param_2,undefined4 param_3);
undefined4 FUN_0042e96c(int param_1);
void FUN_0042e97c(int param_1,char param_2);
void FUN_0042e99c(int *param_1,int param_2,undefined4 param_3);
bool FUN_0042ea18(int param_1);
void FUN_0042ea30(int param_1,undefined param_2);
void FUN_0042ea64(int *param_1,int *param_2);
void FUN_0042eaf8(int *param_1,int param_2,byte param_3);
void FUN_0042eb3c(int *param_1,uint param_2,undefined4 param_3);
void FUN_0042ebd0(int *param_1,int param_2,int param_3,int *param_4,int *param_5);
void FUN_0042ec68(int param_1);
void FUN_0042ed44(int *param_1,undefined4 param_2);
void FUN_0042ed64(int *param_1,undefined4 param_2);
void FUN_0042ed88(int *param_1,undefined4 param_2);
void FUN_0042eda8(int *param_1,undefined4 param_2);
void FUN_0042edc8(int *param_1,int *param_2,undefined4 *param_3);
void FUN_0042eed4(int *param_1,int param_2,int *param_3);
void FUN_0042ef2c(int *param_1,undefined4 param_2);
void FUN_0042ef58(int param_1,undefined4 *param_2);
void FUN_0042ef78(int *param_1,int *param_2);
undefined4 FUN_0042efb4(int *param_1);
void FUN_0042efcc(int *param_1,undefined4 param_2);
undefined4 FUN_0042eff8(int *param_1);
void FUN_0042f010(int *param_1,undefined4 param_2);
void FUN_0042f038(int param_1,int *param_2);
void FUN_0042f0c8(int *param_1,int *param_2,int *param_3);
void FUN_0042f0f4(int *param_1,int *param_2,int *param_3);
void FUN_0042f120(int *param_1,undefined4 param_2);
void FUN_0042f150(int param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4);
void FUN_0042f1bc(int param_1);
void FUN_0042f1cc(int *param_1,int param_2,int param_3);
void FUN_0042f3d4(int *param_1,int *param_2);
void FUN_0042f41c(int *param_1,int *param_2,undefined4 param_3);
void FUN_0042f468(int *param_1,uint param_2,undefined4 param_3);
void FUN_0042f4ac(int param_1,char param_2);
void FUN_0042f4c4(int param_1);
void FUN_0042f4d4(int param_1,undefined4 param_2,undefined4 param_3);
int FUN_0042f4e0(int param_1);
int FUN_0042f4f4(int param_1);
void FUN_0042f508(int *param_1,int *param_2);
void FUN_0042f52c(int param_1,undefined4 param_2);
void FUN_0042f550(int param_1,int *param_2);
void FUN_0042f580(int param_1,uint *param_2);
void FUN_0042f600(int param_1);
void FUN_0042f63c(int param_1);
void FUN_0042f674(int param_1,char param_2);
void FUN_0042f694(int param_1,char param_2);
void FUN_0042f6dc(int param_1,int param_2);
void FUN_0042f700(int param_1,char param_2);
void FUN_0042f720(int param_1,char param_2);
void FUN_0042f740(int param_1,short param_2);
uint FUN_0042f75c(HANDLE param_1);
void FUN_0042f76c(int *param_1,char param_2);
void FUN_0042f794(int *param_1,undefined4 param_2,undefined4 param_3);
void FUN_0042f7a4(int *param_1,int param_2);
void FUN_0042f848(int param_1);
uint FUN_0042f8f0(undefined param_1,undefined param_2,undefined param_3,int param_4);
void FUN_0042f97c(int param_1,char param_2,char param_3);
void FUN_0042fa2c(int *param_1);
undefined4 FUN_0042fb30(int param_1);
undefined4 FUN_0042fb60(uint param_1);
void FUN_0042fb94(int *param_1,char param_2,int param_3);
uint FUN_0042fc5c(uint param_1);
void FUN_0042fcd0(int param_1,undefined4 param_2);
void FUN_0042fcf0(int param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4);
void FUN_0042fdec(int *param_1,undefined4 param_2,undefined4 param_3);
void FUN_0042fe4c(undefined4 param_1,int *param_2,char param_3);
void FUN_0042ff9c(int *param_1,int param_2);
uint FUN_0043008c(int *param_1,int *param_2,int param_3,undefined param_4);
uint FUN_00430274(int *param_1,undefined4 *param_2);
uint FUN_00430324(uint param_1,undefined4 param_2,undefined4 param_3);
undefined4 FUN_00430354(int *param_1,undefined4 *param_2,undefined4 *param_3);
undefined4 FUN_004303c0(int *param_1,int **param_2,int **param_3);
void FUN_004303f0(int param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4,undefined4 param_5);
void FUN_00430420(int *param_1,int **param_2,int **param_3);
undefined4 FUN_004304f4(int param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4);
uint FUN_00430528(int *param_1);
void FUN_00430598(int param_1,int *param_2);
void FUN_004305c0(int *param_1,uint *param_2,undefined4 param_3);
void FUN_004306d8(int param_1,int *param_2);
uint FUN_00430780(undefined param_1,undefined param_2,undefined param_3,int param_4);
void FUN_004307b0(undefined4 param_1,int *param_2);
void FUN_00430800(int param_1);
void FUN_004308c4(int *param_1,int param_2,byte param_3,byte param_4);
void FUN_00430908(int *param_1,int param_2);
void FUN_00430954(int *param_1,undefined4 param_2);
void FUN_00430970(int *param_1,int param_2);
char FUN_004309c8(int *param_1,int **param_2,int **param_3);
void FUN_00430b04(int param_1,byte param_2,uint param_3,undefined4 param_4);
void FUN_00430b34(int *param_1,int param_2);
void FUN_00430b70(int param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4,undefined4 param_5);
void FUN_00430ba8(int *param_1,int param_2,uint param_3);
void FUN_00430cdc(int *param_1,int param_2);
void FUN_00430dbc(int *param_1);
void FUN_00430dc4(int *param_1);
void FUN_00430dcc(int param_1,int param_2);
void FUN_00430e1c(int *param_1,int param_2);
void FUN_00430e34(int param_1);
void FUN_00430e5c(int param_1,int param_2);
void FUN_00430e8c(int param_1);
int * FUN_00430eec(int *param_1,undefined4 *param_2);
void FUN_00430f74(undefined param_1,undefined param_2,undefined param_3,int param_4);
void FUN_00431060(int *param_1,int *param_2,char param_3);
undefined4 FUN_004311a0(int param_1);
undefined4 FUN_004311c0(int param_1);
undefined4 FUN_004311e0(int param_1);
undefined4 FUN_00431200(int param_1);
void FUN_00431220(int *param_1);
void FUN_00431258(int *param_1,int *param_2);
int FUN_00431300(double *param_1,int param_2);
undefined4 FUN_004313ec(int *param_1);
uint FUN_0043143c(int *param_1,uint param_2,undefined4 param_3);
undefined4 FUN_0043147c(int param_1);
void FUN_004314a8(int param_1,int param_2);
void FUN_004314d4(int *param_1,int param_2);
void FUN_0043161c(int param_1,int *param_2);
void FUN_00431694(int *param_1,char param_2,int *param_3);
void FUN_004317b0(int *param_1,char param_2);
void FUN_00431884(int param_1,undefined4 param_2,undefined4 param_3);
void FUN_00431958(int *param_1,int *param_2);
void FUN_004319d0(void);
uint FUN_004319d4(int param_1,int param_2,char param_3);
void FUN_00431a34(int *param_1,byte param_2,undefined4 param_3,int param_4);
void FUN_00431dd0(byte param_1,undefined4 param_2,undefined4 param_3,int param_4);
undefined4 FUN_00431f24(undefined param_1,undefined param_2,undefined param_3,int param_4);
void FUN_00431f78(int *param_1,undefined4 param_2,undefined4 param_3);
void FUN_00432064(int *param_1,undefined4 param_2);
void FUN_004320f8(int param_1);
void FUN_00432100(int param_1);
void FUN_00432120(int *param_1);
void FUN_00432128(int *param_1,undefined4 param_2,undefined4 param_3);
void FUN_004321fc(int *param_1,undefined param_2);
uint thunk_FUN_00432341(uint param_1,uint param_2);
uint FUN_00432341(uint param_1,uint param_2);
void FUN_00432350(int *param_1,char param_2);
void FUN_00432370(int param_1,int *param_2);
void FUN_004323bc(int param_1,int *param_2);
void FUN_00432404(int *param_1,int *param_2,undefined4 param_3);
void FUN_004324d8(int *param_1,int *param_2);
void FUN_00432554(int param_1,int param_2);
int FUN_00432590(int param_1);
void FUN_004325b0(int param_1,int param_2);
void FUN_004325f0(int param_1,uint param_2);
void FUN_00432618(undefined4 param_1,int param_2,LPCSTR param_3);
void FUN_00432684(int *param_1,uint *param_2);
void FUN_004326ec(int *param_1,int *param_2);
void FUN_00432818(int *param_1);
void FUN_004329b0(int param_1,LPCSTR *param_2);
void FUN_004329f4(int *param_1);
void FUN_00432a4c(int param_1);
int FUN_00432ab0(int param_1,int param_2);
void FUN_00432af8(int *param_1);
void FUN_00432b90(int *param_1);
void FUN_00432bd8(int param_1);
void FUN_00432bf0(int *param_1,undefined4 param_2,undefined4 param_3);
void FUN_00432c2c(int *param_1);
void FUN_00432d28(int *param_1);
void FUN_00432de0(int *param_1,undefined4 param_2,undefined4 param_3,int param_4);
undefined4 FUN_00432e98(int param_1,undefined4 param_2,undefined4 param_3,char param_4);
bool FUN_00432f2c(int *param_1,undefined4 *param_2);
void FUN_00432fc0(int *param_1,uint *param_2,undefined4 param_3);
void FUN_004331a0(int param_1,UINT *param_2);
bool FUN_0043329c(HWND param_1,int *param_2);
void FUN_004332d0(int *param_1,int param_2);
void FUN_00433428(int param_1,HDC param_2,int param_3);
void FUN_00433658(int *param_1,int param_2);
void FUN_004337d8(int *param_1,int *param_2);
void FUN_0043391c(int *param_1,int param_2);
void FUN_00433968(int *param_1,int param_2);
void FUN_00433a28(int *param_1,int param_2);
void FUN_00433a78(int *param_1,undefined4 param_2);
void FUN_00433ac0(int *param_1,int param_2);
void FUN_00433bc0(int *param_1);
void FUN_00433c10(int *param_1,undefined4 param_2,undefined4 param_3);
void FUN_00433d94(undefined4 param_1,int *param_2);
void FUN_00433d9c(void);
void FUN_00433da0(int param_1);
void FUN_00433dc0(int param_1);
void FUN_00433e30(int param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4,byte param_5,uint param_6);
undefined FUN_00433ea4(int param_1,undefined4 param_2,undefined4 param_3);
void FUN_00433efc(int param_1,char *param_2,undefined4 *param_3);
undefined4 FUN_00433f20(int param_1);
undefined4 FUN_00433f34(int param_1,int param_2);
int FUN_00433fb4(int param_1);
void FUN_0043405c(int *param_1,char param_2,undefined4 param_3);
void FUN_00434110(int *param_1,int param_2);
void FUN_00434200(int param_1,int param_2);
uint FUN_004342d4(int *param_1,int param_2);
void FUN_0043433c(int *param_1,int param_2);
uint FUN_004343a4(int *param_1,int param_2);
void FUN_0043444c(int param_1,undefined4 param_2);
uint FUN_0043446c(int *param_1,int param_2,undefined4 param_3);
void FUN_004344f8(int *param_1,int param_2);
void FUN_00434554(int *param_1,int param_2,undefined4 param_3);
uint FUN_004346b4(uint param_1,byte param_2,undefined4 *param_3);
uint FUN_0043474c(int *param_1,undefined4 param_2,undefined4 param_3,int param_4);
void FUN_004347fc(int *param_1,int param_2,undefined4 param_3);
void FUN_004348c4(int *param_1,int *param_2);
void FUN_00434918(int *param_1);
void FUN_00434968(int *param_1,int param_2);
void FUN_00434a14(int *param_1,int param_2,undefined4 param_3);
void FUN_00434a4c(int *param_1,int param_2);
void FUN_00434a84(int *param_1,undefined4 param_2,undefined4 param_3);
void FUN_00434b48(int param_1,int param_2);
void FUN_00434b50(int param_1,int param_2);
void FUN_00434b58(int param_1,int param_2);
void FUN_00434b60(int *param_1);
void FUN_00434b90(int param_1);
void FUN_00434bb8(int *param_1);
void FUN_00434c00(int *param_1);
void FUN_00434c28(int *param_1);
void FUN_00434ca4(int *param_1);
void FUN_00434cd4(uint param_1,undefined4 param_2);
void FUN_00434d54(int param_1,int param_2);
void FUN_00434d5c(int param_1,int param_2);
void FUN_00434d74(int *param_1,int param_2);
void FUN_00434dd0(int param_1);
void FUN_00434de4(int param_1,int param_2);
uint FUN_00434e00(int *param_1,int param_2,undefined4 param_3);
void FUN_00434e94(int *param_1,int param_2,undefined4 param_3);
void FUN_0043500c(int *param_1,int param_2,undefined4 param_3);
void FUN_00435178(int param_1,undefined4 param_2,undefined4 param_3);
void FUN_004351c0(int *param_1,int param_2,int param_3);
void FUN_00435220(int *param_1,int param_2,int param_3);
void FUN_004352f8(int param_1);
void FUN_00435310(int param_1,int param_2);
void FUN_00435518(int *param_1);
void FUN_00435530(int param_1);
undefined4 FUN_004355e0(int param_1);
void FUN_00435604(int *param_1);
int FUN_00435628(int *param_1);
void FUN_004356f0(int *param_1,LPRECT param_2);
void FUN_00435708(int *param_1);
void FUN_00435748(int param_1,int param_2);
void FUN_00435768(int param_1,char param_2);
int FUN_004357bc(int param_1);
void FUN_004357e0(int param_1,short param_2);
void FUN_00435854(uint param_1,char param_2);
void FUN_004358b4(int *param_1,byte param_2,undefined4 param_3);
uint FUN_00435924(uint param_1);
void FUN_00435930(int param_1);
void FUN_004359e8(int param_1,undefined **param_2);
void FUN_00435a40(int *param_1,int param_2,undefined4 param_3,char param_4,char param_5);
void FUN_00435b78(int *param_1);
void FUN_00435bbc(int param_1,int param_2,undefined4 param_3,undefined *param_4,undefined4 param_5);
void FUN_00435c04(undefined4 param_1,int *param_2,int param_3);
void FUN_00435c4c(int *param_1,undefined4 *param_2,undefined4 *param_3,undefined4 *param_4,undefined4 *param_5);
void FUN_00435ccc(int *param_1,int *param_2,int *param_3,int *param_4,int *param_5);
uint FUN_0043617c(int *param_1,undefined4 param_2,undefined4 param_3);
void FUN_00436340(int *param_1,int param_2);
void FUN_00436658(int *param_1,int param_2);
int * FUN_004366c4(int *param_1,char param_2,int *param_3);
void FUN_00436720(int *param_1,char param_2);
void FUN_00436760(int *param_1,int param_2);
int * FUN_0043680c(int *param_1,char param_2,int *param_3);
void FUN_00436a38(int *param_1);
void FUN_00436ad8(int *param_1,int *param_2,uint *param_3);
void FUN_00436bf4(int *param_1,undefined4 *param_2,undefined4 param_3);
void FUN_00436c20(int param_1,undefined4 param_2,undefined *param_3,LPRECT param_4);
void FUN_00436c7c(HWND param_1,int param_2,int param_3,int *param_4);
void FUN_00436cbc(int *param_1,undefined4 param_2,undefined4 param_3);
void FUN_00436cd4(int param_1);
bool FUN_00436da0(int *param_1,int param_2,int param_3,int param_4);
void FUN_00436de8(int param_1,short param_2);
undefined FUN_00436e2c(int *param_1,HWND param_2,int param_3,int param_4);
bool FUN_00436e8c(uint param_1,HWND param_2,int param_3,int param_4);
void FUN_00436ef0(uint param_1);
bool FUN_00436f14(uint param_1,int param_2,int param_3);
void FUN_00436f58(uint param_1);
void FUN_00436f70(uint param_1);
bool FUN_00436f88(uint param_1);
int * FUN_00436fd0(int *param_1,char param_2,int *param_3);
void FUN_0043702c(int *param_1,char param_2);
void FUN_0043712c(int *param_1,char param_2,int param_3);
int FUN_00437150(int param_1);
void FUN_00437164(int param_1);
void FUN_004371ac(int param_1);
undefined4 FUN_004371f4(int param_1,char param_2);
int FUN_00437260(int param_1,char param_2);
void FUN_00437308(int param_1);
void FUN_00437398(int param_1,int *param_2);
uint FUN_004373dc(int param_1,undefined4 param_2);
undefined4 FUN_00437460(undefined param_1,undefined param_2,undefined param_3,int param_4);
void FUN_00437488(int param_1);
void FUN_004375d8(int *param_1,char param_2,int param_3);
void FUN_004377a0(int param_1);
void FUN_004377a4(int param_1);
void FUN_004377b8(int param_1,undefined4 param_2,int param_3,int param_4);
undefined4 FUN_00437810(int param_1,int param_2,int param_3);
void FUN_0043783c(int param_1,undefined4 param_2,undefined4 param_3,int param_4);
void FUN_00437878(int param_1,int param_2,undefined4 param_3);
void FUN_00437890(int param_1,int param_2,undefined4 *param_3);
void FUN_00437b24(int param_1,int param_2,int param_3,char param_4,undefined param_5);
void FUN_00437cac(int param_1,int param_2,int param_3,char param_4);
void FUN_00437d1c(int param_1,int param_2,undefined4 param_3,int param_4);
int * FUN_00437f24(int *param_1,undefined4 param_2,undefined4 param_3,int param_4);
int FUN_00437fb8(int param_1,int *param_2,undefined4 *param_3);
void FUN_00438044(int *param_1,undefined4 param_2,uint param_3,int param_4);
void FUN_0043808c(int param_1,int *param_2);
void FUN_00438294(int param_1,int param_2,undefined4 param_3,int param_4);
void FUN_004382ec(int param_1,int param_2,int param_3,int param_4,int param_5);
void FUN_00438374(int param_1,undefined4 param_2,undefined4 param_3,int *param_4);
void FUN_00438730(int *param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4);
void FUN_00438764(int param_1,int *param_2,undefined4 param_3);
void FUN_004387fc(int param_1,int *param_2);
void FUN_00438b68(int param_1,undefined4 param_2,undefined4 param_3,int param_4);
void FUN_00438be0(int param_1,int param_2,undefined4 param_3,int param_4);
void FUN_00438de4(int param_1,undefined4 param_2,int param_3,int param_4);
void FUN_00438e4c(int param_1,int param_2,int param_3);
void FUN_00438eac(int param_1,undefined4 param_2,undefined4 *param_3);
void FUN_00438f0c(int param_1);
void FUN_00438f84(int param_1);
void FUN_00438fbc(int param_1);
int FUN_004390a8(int param_1,int param_2);
void FUN_004390b0(int param_1,undefined4 param_2,int param_3,int param_4);
int FUN_0043912c(int param_1,int param_2,undefined4 param_3);
undefined4 FUN_00439170(int param_1,int param_2);
void FUN_004391ec(int *param_1,int param_2,int param_3);
void FUN_00439258(undefined param_1,undefined param_2,undefined param_3,int param_4);
int * FUN_004396cc(int *param_1,char param_2,undefined4 param_3);
void FUN_0043978c(void);
void FUN_00439794(undefined4 param_1,LPPOINT param_2);
void FUN_004397a4(int param_1,undefined4 param_2,undefined4 param_3);
int FUN_004397c0(int param_1,undefined4 param_2,undefined4 param_3);
void FUN_004397f0(int param_1,undefined4 param_2,LRESULT param_3);
void FUN_00439818(undefined4 param_1,HWND param_2);
void FUN_00439840(int param_1,int param_2,undefined4 param_3);
void FUN_004398a4(undefined4 param_1,undefined4 param_2,undefined4 param_3);
undefined4 FUN_00439b0c(void);
void FUN_00439b28(undefined4 param_1,char param_2);
undefined4 FUN_00439c04(void);
void FUN_00439c18(void);
void FUN_00439c8c(void);
void FUN_0043a1b8(int *param_1,char param_2);
int FUN_0043a1ec(int param_1);
void FUN_0043a228(int *param_1,int *param_2,uint param_3);
void FUN_0043a25c(int param_1,int param_2);
void FUN_0043a2d0(int param_1,int param_2);
void FUN_0043a4d4(int param_1,int *param_2,int param_3);
void FUN_0043a504(int param_1,int param_2);
void FUN_0043a544(int param_1,int *param_2,byte param_3);
void FUN_0043a58c(int param_1,int param_2);
void FUN_0043a5ac(int param_1,int param_2);
void FUN_0043a5c8(int param_1);
undefined4 FUN_0043a630(int param_1,int param_2);
void FUN_0043a6d0(int param_1);
void FUN_0043a6e4(int param_1);
void FUN_0043a6f8(int param_1);
void FUN_0043a70c(int param_1);
void FUN_0043a720(int param_1);
void FUN_0043a734(int param_1);
void FUN_0043a748(int param_1);
void FUN_0043a75c(int param_1);
int * FUN_0043a790(int *param_1,char param_2,int *param_3);
void FUN_0043a88c(int *param_1,uint *param_2);
void FUN_0043a8f4(int *param_1,undefined4 param_2);
void FUN_0043a94c(int *param_1,undefined4 param_2);
void FUN_0043a9a4(int *param_1,int param_2);
void FUN_0043a9fc(int *param_1,uint *param_2);
void FUN_0043aa64(int *param_1,int param_2);
void FUN_0043aabc(int *param_1,undefined4 param_2);
void FUN_0043ab18(int *param_1,undefined4 param_2);
void FUN_0043ab70(int *param_1,uint *param_2);
void FUN_0043ac00(void);
int FUN_0043adfc(uint param_1);
int FUN_0043ae1c(int param_1);
int * FUN_0043ae3c(int *param_1,char param_2,int *param_3);
int * FUN_0043ae88(int *param_1,char param_2,int param_3,int param_4);
void FUN_0043af48(int *param_1,undefined4 param_2,undefined4 param_3);
uint FUN_0043b000(uint param_1);
void FUN_0043b008(int *param_1);
void FUN_0043b014(int param_1);
void FUN_0043b0d8(int param_1,HIMAGELIST param_2);
void FUN_0043b110(int *param_1,int param_2);
void FUN_0043b154(int *param_1,int param_2);
void FUN_0043b198(int *param_1,HIMAGELIST param_2);
int FUN_0043b1c4(int param_1,int param_2);
int FUN_0043b1d4(int *param_1);
void FUN_0043b1e4(int param_1,int *param_2,int *param_3);
void FUN_0043b238(int *param_1);
void FUN_0043b26c(int *param_1);
void FUN_0043b308(int *param_1,int *param_2,int *param_3);
void FUN_0043b3d4(int *param_1,int *param_2,int param_3);
int FUN_0043b4f0(int *param_1);
void FUN_0043b514(int *param_1,int param_2);
void FUN_0043b5a0(int *param_1);
void FUN_0043b5ac(int *param_1,uint param_2);
int FUN_0043b5e4(int *param_1);
void FUN_0043b60c(int *param_1,int param_2,int *param_3,char param_4,UINT param_5,int param_6,int param_7);
void FUN_0043b7e4(int *param_1,undefined4 param_2,undefined4 param_3,byte param_4,undefined4 param_5,undefined4 param_6);
void FUN_0043b830(int *param_1,HIMAGELIST param_2);
void FUN_0043b9c8(int *param_1,int *param_2);
void FUN_0043bb58(int param_1,int *param_2);
void FUN_0043bbd0(int *param_1,undefined4 param_2,undefined4 param_3);
void FUN_0043bbec(undefined4 param_1,undefined4 *param_2);
void FUN_0043bbfc(int param_1);
void FUN_0043bc4c(int param_1,int param_2);
void FUN_0043bc90(int param_1,int param_2);
undefined4 FUN_0043bca4(int *param_1,int *param_2);
uint FUN_0043bce4(int *param_1,int *param_2);
bool FUN_0043bdd4(undefined param_1,undefined param_2,undefined param_3,int param_4);
void FUN_0043be88(int *param_1,int *param_2);
void FUN_0043c118(int *param_1,int param_2,undefined4 param_3);
void FUN_0043c224(int *param_1,int param_2,undefined4 param_3);
void FUN_0043c2a0(int param_1);
void FUN_0043c2a4(int *param_1,undefined4 param_2,undefined4 param_3);
HANDLE FUN_0043d1d8(POINT *param_1);
undefined4 FUN_0043d208(undefined param_1,undefined param_2,undefined param_3,undefined param_4,undefined4 param_5);
void FUN_0043d210(int **param_1);
short FUN_0043d230(short param_1,byte param_2);
void FUN_0043d268(undefined2 param_1,int *param_2);
void FUN_0043d2bc(ushort param_1,int *param_2);
undefined4 FUN_0043d4c0(int *param_1,undefined *param_2);
void FUN_0043d51c(undefined *param_1);
uint FUN_0043d614(void);
uint FUN_0043d634(int *param_1,int param_2,undefined *param_3,int param_4);
void FUN_0043d694(undefined *param_1,int param_2,int param_3);
undefined4 FUN_0043d820(int param_1);
undefined4 FUN_0043d850(int param_1);
undefined4 FUN_0043d880(int param_1);
undefined4 FUN_0043d8b4(int param_1);
undefined4 FUN_0043d8e4(int param_1);
undefined4 FUN_0043d948(int param_1);
int * FUN_0043da9c(int *param_1,char param_2,int *param_3);
void FUN_0043dbcc(uint param_1,HMENU param_2,byte param_3);
void FUN_0043de6c(uint param_1);
void FUN_0043dedc(int *param_1,int param_2,uint param_3);
void FUN_0043df34(int *param_1,int param_2);
void FUN_0043df58(int *param_1);
void FUN_0043df94(int *param_1);
void FUN_0043e018(int param_1,int param_2,byte param_3);
undefined4 FUN_0043e078(uint param_1);
void FUN_0043e108(int param_1,int *param_2,int param_3,uint param_4,char param_5,LPRECT param_6);
void FUN_0043e360(undefined param_1,undefined param_2,undefined param_3,int param_4);
void FUN_0043ebe0(undefined param_1,undefined param_2,undefined param_3,int param_4);
undefined4 FUN_0043f5a0(int param_1);
void FUN_0043f5d0(undefined param_1,undefined param_2,undefined param_3,int param_4);
void FUN_0043f61c(int *param_1,int *param_2,int *param_3,int *param_4);
void FUN_0043f830(int *param_1,uint *param_2);
void FUN_0043f858(int param_1);
void FUN_0043f8a0(int param_1,byte param_2);
void FUN_0043f8f4(int *param_1,byte param_2);
void FUN_0043f96c(int param_1,byte param_2);
undefined4 FUN_0043f9b0(int param_1);
undefined4 FUN_0043f9c8(int param_1);
void FUN_0043f9d8(int param_1,int param_2);
void FUN_0043f9fc(int *param_1,short param_2);
void FUN_0043fa10(int *param_1,char param_2);
void FUN_0043fa20(int *param_1,int param_2);
void FUN_0043fb54(int *param_1,int param_2,int param_3);
void FUN_0043fc04(int *param_1,int param_2);
int FUN_0043fce4(int param_1,int param_2);
void FUN_0043fd18(int *param_1,int param_2);
void FUN_0043fd7c(int *param_1,undefined4 param_2,undefined4 param_3,char param_4);
undefined4 FUN_0043fdd4(int param_1,undefined4 param_2,undefined4 param_3);
void FUN_0043fdfc(int *param_1,int param_2,undefined4 param_3);
void FUN_0043fea0(int param_1);
undefined4 thunk_FUN_0043ff38(int param_1);
undefined4 FUN_0043ff38(int param_1);
void FUN_0043ff44(int *param_1,char param_2);
undefined4 FUN_004400a0(int param_1);
undefined4 FUN_004400c0(int param_1);
undefined4 FUN_004400e0(int param_1);
undefined4 FUN_00440100(int param_1);
undefined4 FUN_00440120(int param_1);
undefined4 FUN_00440140(int param_1);
undefined4 FUN_00440160(int param_1);
undefined4 FUN_00440180(int param_1);
void FUN_004401a0(int *param_1,int *param_2);
void FUN_00440218(int *param_1,int param_2,byte param_3);
undefined4 FUN_00440294(int *param_1);
void FUN_004402bc(int param_1);
uint FUN_004402d0(undefined *param_1,undefined4 param_2,undefined4 param_3,int param_4);
void FUN_00440300(undefined param_1,undefined param_2,undefined param_3,int param_4);
void FUN_00440384(int *param_1,undefined4 param_2,int param_3);
void FUN_004404e4(int param_1,char param_2);
uint FUN_00440990(int param_1);
uint FUN_004409b4(uint param_1,char param_2);
undefined FUN_00440b00(int param_1);
undefined FUN_00440b2c(int param_1);
int * FUN_00440b58(int *param_1,char param_2,int *param_3);
void FUN_00440bf0(int *param_1,char param_2);
void FUN_00440c44(int param_1);
undefined4 FUN_00440c64(int *param_1);
void FUN_00440c8c(int param_1);
uint FUN_00440ca4(int param_1,undefined4 param_2,undefined4 param_3,uint param_4);
undefined4 FUN_00440d3c(int param_1);
undefined4 FUN_00440d6c(int *param_1,int param_2,char param_3);
bool FUN_00440ddc(int param_1);
undefined4 FUN_00440df8(int *param_1);
undefined4 FUN_00440e6c(int param_1);
void thunk_FUN_00440e86(int param_1,int param_2);
void FUN_00440e86(int param_1,int param_2);
uint FUN_00440e90(int **param_1,int param_2,undefined4 param_3,int *param_4);
void FUN_004410a8(int *param_1);
void FUN_00441164(HMENU param_1,undefined4 param_2,undefined4 param_3,int param_4);
undefined4 FUN_00441204(int *param_1);
void FUN_00441288(int param_1,char param_2);
void FUN_00441298(int *param_1);
void FUN_00441314(int *param_1,int param_2);
void FUN_00441364(int *param_1);
void FUN_0044137c(int *param_1,undefined4 param_2,uint param_3,byte param_4);
void FUN_004413c4(int param_1,int param_2);
undefined4 FUN_0044142c(int param_1);
undefined4 FUN_00441444(HMENU param_1,uint param_2,int param_3,byte param_4,int param_5);
void FUN_004414a0(HMENU param_1,ushort param_2,int param_3,byte param_4,int param_5);
void FUN_00441588(undefined4 param_1,int param_2);
int FUN_00441700(int param_1,HMENU param_2,UINT param_3,UINT param_4,int param_5,undefined4 *param_6);
void FUN_004417a8(int *param_1,char param_2);
void FUN_004417cc(int *param_1);
void FUN_004417f4(int *param_1,int *param_2);
void FUN_00441880(int *param_1,undefined4 param_2,uint param_3,byte param_4);
void FUN_004418d8(int param_1,int param_2);
void FUN_004418f4(int param_1,int param_2);
void FUN_00441910(int *param_1);
void FUN_0044194c(int *param_1);
void FUN_00441ed4(undefined **param_1,int param_2);
void FUN_00441efc(int *param_1,int param_2);
int * FUN_00441f18(int *param_1,char param_2,int *param_3);
void FUN_00441f8c(int *param_1,char param_2);
undefined4 FUN_00441fd4(int param_1);
void FUN_00441fdc(int param_1,undefined4 param_2);
void FUN_00441fe4(int *param_1);
uint FUN_0044202c(int param_1);
void FUN_00442078(int *param_1,int param_2,int param_3);
void FUN_0044214c(int param_1,int param_2);
void FUN_00442188(int *param_1,int param_2,undefined4 *param_3,uint param_4);
void FUN_0044227c(undefined4 *param_1,int *param_2);
void FUN_00442314(int param_1,int *param_2);
void FUN_00442378(undefined4 *param_1,undefined4 *param_2);
void FUN_00444908(HWND param_1,char param_2);
void FUN_00444954(void);
void FUN_004449dc(undefined4 param_1);
void FUN_00444a90(int *param_1);
undefined4 FUN_00444ac8(undefined param_1,undefined param_2,undefined param_3,HWND param_4);
int FUN_00444b2c(undefined4 param_1);
uint FUN_00444b68(HWND param_1,uint param_2);
undefined4 FUN_00444b88(undefined param_1,undefined param_2,undefined param_3,int param_4,int *param_5);
uint FUN_00444ba8(void);
void FUN_00444c54(void);
int FUN_00444c78(int param_1,int param_2);
undefined *FUN_00444c80(undefined param_1,undefined param_2,undefined param_3,undefined4 param_4,undefined4 param_5);
void FUN_00444d18(int param_1);
HWND FUN_00444d3c(undefined param_1,undefined param_2,undefined param_3,undefined4 param_4,undefined4 param_5);
void FUN_00444df0(HWND param_1);
byte FUN_00444e18(uint param_1);
byte FUN_00444e6c(uint param_1);
byte FUN_00444ea8(int param_1);
void FUN_00444ef4(undefined4 param_1,int param_2);
int * FUN_00444f64(int *param_1);
void FUN_00444f8c(int *param_1);
int * FUN_0044500c(int *param_1,char param_2,int param_3,undefined param_4);
void FUN_004450ec(int param_1);
void FUN_00445124(int param_1,undefined4 param_2,undefined4 param_3,int param_4);
void FUN_00445190(int param_1,undefined4 param_2,undefined4 param_3,int param_4);
void FUN_004451f8(int param_1);
undefined4 FUN_004452a4(int param_1);
uint FUN_004452dc(short param_1,undefined4 param_2,undefined4 param_3,int param_4);
int FUN_00445310(short param_1,undefined4 param_2,int param_3,int param_4);
int FUN_0044538c(int param_1);
uint FUN_0044540c(int param_1);
int FUN_00445424(undefined param_1,undefined param_2,undefined param_3,int param_4);
uint FUN_00445484(uint param_1,uint param_2);
void FUN_004457f4(int param_1,int param_2);
void FUN_0044592c(int param_1,int param_2);
void FUN_00445944(int param_1,int param_2);
void FUN_00445964(int param_1,undefined param_2);
void FUN_00445970(char param_1,undefined param_2,undefined param_3,int param_4);
void FUN_00445a78(int param_1);
int * FUN_00445b90(int *param_1,char param_2,int *param_3);
void FUN_00445bf8(int *param_1,char param_2);
void FUN_00445c34(int *param_1,int *param_2);
void FUN_00445c44(int *param_1);
void FUN_00445c70(int *param_1,undefined4 param_2,undefined4 param_3);
void FUN_00445dc8(int param_1);
void FUN_00445dec(int param_1,char param_2);
void FUN_00445e48(uint param_1);
void FUN_00445f58(int *param_1,int *param_2);
void FUN_004460ac(int param_1,int param_2,int param_3);
void FUN_00446150(int *param_1,int param_2,int param_3);
void FUN_0044629c(int *param_1,undefined4 *param_2);
void FUN_00446310(int *param_1,int param_2);
void FUN_00446498(int *param_1,char param_2,undefined4 param_3);
void FUN_00446624(int *param_1,undefined4 param_2,undefined4 param_3);
int * FUN_0044665c(int *param_1,char param_2,int *param_3);
void FUN_00446824(int *param_1,char param_2);
void FUN_00446908(int *param_1,undefined4 param_2,undefined *param_3);
void FUN_0044697c(int param_1);
void FUN_004469dc(int *param_1);
void FUN_00446a18(int *param_1,int *param_2,undefined4 param_3);
void FUN_00446e54(int param_1);
void FUN_00446efc(int *param_1);
undefined4 FUN_00446f90(uint param_1);
undefined4 FUN_00447118(int *param_1);
void FUN_00447144(int param_1,int *param_2,int param_3);
void FUN_00447200(int *param_1,int param_2);
void FUN_00447230(int *param_1,int param_2);
void FUN_00447260(int *param_1,uint param_2,undefined4 param_3);
void FUN_00447744(undefined param_1,undefined param_2,undefined param_3,int param_4);
undefined4 FUN_00447790(undefined param_1,undefined param_2,undefined param_3,int param_4);
void FUN_004478d4(int *param_1,int param_2,uint param_3);
void FUN_00447a20(int param_1,char param_2);
void FUN_00447a58(int *param_1,int *param_2,undefined4 *param_3);
void FUN_00447aa0(int *param_1,int param_2,int *param_3);
HANDLE FUN_00447af4(int param_1);
int FUN_00447b28(int param_1);
int FUN_00447b74(int param_1,int param_2);
undefined4 FUN_00447bc4(int *param_1);
undefined4 FUN_00447c24(int param_1);
uint FUN_00447c38(uint param_1);
void FUN_00447c68(int *param_1,undefined4 param_2,undefined4 param_3);
void FUN_00447ce8(int *param_1);
void FUN_00447d64(int param_1,int *param_2,undefined4 param_3);
void FUN_00447d88(int *param_1,int param_2,undefined4 param_3);
void FUN_00447db0(int *param_1,int *param_2);
int FUN_00447f74(int param_1);
void FUN_00447fbc(int param_1,char param_2);
undefined4 FUN_00448038(int param_1);
void FUN_00448098(int *param_1);
void FUN_004480d4(int *param_1,byte param_2);
void FUN_00448114(int *param_1);
void FUN_00448460(int *param_1,int *param_2);
void FUN_0044895c(int *param_1,int *param_2,undefined4 param_3);
void FUN_00448a14(int *param_1,uint param_2,char param_3);
void FUN_00448a5c(int *param_1,int *param_2,undefined4 param_3);
void FUN_00448d14(int *param_1);
void FUN_00448dc8(int param_1,undefined4 param_2);
void FUN_00448e18(int param_1,char param_2);
void FUN_00448ec0(UINT param_1,int *param_2,int *param_3);
void FUN_00448f3c(int *param_1);
void FUN_00448f8c(int param_1);
void FUN_00449238(undefined param_1,undefined param_2,undefined param_3,int param_4);
void FUN_00449368(int *param_1,int param_2);
void FUN_00449668(int *param_1,int *param_2,undefined4 param_3);
int FUN_0044982c(int *param_1,undefined4 param_2,undefined4 param_3,int param_4);
void FUN_00449a9c(int *param_1,undefined4 param_2,undefined4 param_3);
void FUN_0044a0d4(int *param_1);
void FUN_0044a1c0(int *param_1,undefined4 param_2,undefined4 param_3);
void FUN_0044a2c8(int *param_1);
void FUN_0044a370(int *param_1,undefined4 param_2,undefined4 param_3);
void FUN_0044a378(int *param_1,undefined4 param_2,undefined4 param_3);
void FUN_0044a40c(int *param_1);
void FUN_0044a428(int *param_1);
void FUN_0044a6c8(int param_1,undefined param_2,undefined param_3,undefined4 param_4);
undefined4 FUN_0044a7e0(int *param_1,undefined4 param_2,undefined4 param_3,int param_4);
undefined4 FUN_0044a810(int param_1,undefined4 param_2,undefined4 param_3,int param_4);
void FUN_0044a88c(int *param_1,int param_2,undefined4 param_3);
undefined4 FUN_0044a8e0(int *param_1,undefined4 param_2,undefined4 param_3,int param_4);
undefined4 FUN_0044a910(int param_1,undefined4 param_2,undefined4 param_3,int param_4);
void FUN_0044a98c(int *param_1,int param_2,undefined4 param_3);
undefined4 FUN_0044a9e0(undefined param_1,undefined param_2,undefined param_3,int param_4);
undefined4 FUN_0044aa34(int param_1,undefined4 param_2,undefined4 param_3);
undefined4 FUN_0044aab0(undefined param_1,undefined param_2,undefined param_3,int param_4,undefined4 param_5,int **param_6);
int * FUN_0044ab5c(int *param_1,char param_2,undefined4 param_3);
void FUN_0044abc4(int *param_1,int *param_2,undefined4 param_3);
void FUN_0044ad18(int param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4,undefined4 param_5);
undefined * FUN_0044af94(int param_1,undefined4 param_2,undefined4 param_3);
int FUN_0044afb4(int param_1,undefined4 param_2,undefined4 param_3);
undefined4 FUN_0044afd8(int param_1,undefined4 param_2,undefined4 param_3);
int FUN_0044aff8(int param_1,undefined4 param_2,undefined4 param_3);
undefined4 FUN_0044b01c(undefined4 param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4,undefined4 param_5,undefined4 param_6,undefined **param_7);
int * FUN_0044b04c(int *param_1,char param_2,int *param_3);
void FUN_0044b21c(undefined4 param_1,undefined4 param_2,undefined4 param_3);
void FUN_0044b228(undefined4 param_1,undefined4 param_2,undefined4 param_3);
void FUN_0044b234(undefined4 param_1,undefined4 param_2,undefined4 param_3);
void FUN_0044b240(undefined4 param_1,undefined4 param_2,undefined4 param_3);
void FUN_0044b24c(undefined4 param_1,undefined4 param_2,undefined4 param_3);
void FUN_0044b258(undefined4 param_1,undefined4 param_2,undefined4 param_3);
void FUN_0044b264(int param_1,int param_2);
int FUN_0044b278(int param_1,undefined4 param_2,undefined4 param_3);
void FUN_0044b294(int param_1,int param_2);
undefined4 FUN_0044b2a8(int param_1);
void FUN_0044b2b0(int param_1,int param_2);
undefined4 FUN_0044b2c4(int param_1);
void FUN_0044b2cc(int param_1);
void FUN_0044b318(int param_1,int *param_2);
void FUN_0044b350(int param_1,int param_2);
void FUN_0044b398(int param_1);
void FUN_0044b3f4(int param_1);
void FUN_0044b450(int param_1,undefined4 param_2,undefined4 param_3);
void FUN_0044b478(int param_1,undefined4 param_2,undefined4 param_3);
void FUN_0044b678(int param_1,int *param_2,undefined4 param_3);
void FUN_0044b6a4(int param_1,int param_2);
undefined4 FUN_0044b6b8(int param_1);
undefined4 FUN_0044b6c0(int param_1,int param_2);
void FUN_0044b6e8(int param_1,short param_2);
void FUN_0044b778(int param_1);
uint FUN_0044b85c(int param_1,int param_2,char param_3);
void FUN_0044b8bc(int *param_1,char param_2,undefined4 param_3,int param_4);
undefined4 FUN_0044bbb8(undefined param_1,undefined param_2,undefined param_3,int param_4);
void FUN_0044bd20(int param_1);
void FUN_0044bd2c(int param_1,int *param_2);
int thunk_FUN_0044bd61(int param_1);
int FUN_0044bd61(int param_1);
void FUN_0044bd7c(void);
LRESULT FUN_0044be2c(undefined param_1,undefined param_2,undefined param_3,int param_4,WPARAM param_5,LPARAM param_6);
void FUN_0044be70(undefined4 param_1,undefined4 param_2,DWORD param_3);
void FUN_0044bee4(void);
uint FUN_0044bf40(void);
void FUN_0044bf70(char param_1);
void FUN_0044bf98(HWND param_1,int param_2);
int * FUN_0044bfd8(int *param_1,char param_2,int *param_3);
void FUN_0044c250(int param_1);
void FUN_0044c3f0(int param_1,int param_2);
undefined4 FUN_0044c450(undefined param_1,undefined param_2,undefined param_3,HWND param_4,HWND *param_5);
void FUN_0044c4c0(int param_1,undefined param_2);
void FUN_0044c568(int param_1);
void FUN_0044c570(int param_1);
void FUN_0044c578(int param_1);
undefined4 FUN_0044c5e4(int param_1);
undefined4 FUN_0044c5fc(int param_1);
undefined4 FUN_0044c614(int param_1,int *param_2);
void FUN_0044c664(undefined param_1,undefined param_2,undefined param_3,int param_4);
void FUN_0044c6a0(undefined param_1,undefined param_2,undefined param_3,int param_4);
void FUN_0044c6ec(int param_1,int *param_2);
void FUN_0044cd88(int param_1);
void FUN_0044cda4(int param_1);
void FUN_0044ce44(int param_1);
void FUN_0044cf34(int param_1);
void FUN_0044cf70(int param_1,int *param_2);
void FUN_0044cfb8(int param_1,uint *param_2);
bool FUN_0044d040(int param_1,LPMSG param_2);
bool FUN_0044d064(int param_1,LPMSG param_2);
undefined4 FUN_0044d0b4(int param_1,HWND *param_2);
undefined4 FUN_0044d16c(int param_1,undefined4 param_2);
undefined4 FUN_0044d19c(int param_1,undefined4 param_2,uint param_3);
undefined4 FUN_0044d208(int param_1,LPMSG param_2,uint param_3);
void FUN_0044d2a0(int param_1,undefined4 param_2,uint param_3);
void FUN_0044d2b8(int param_1,undefined4 param_2,uint param_3);
void FUN_0044d2dc(int param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4,undefined4 param_5);
void FUN_0044d338(int param_1,undefined4 param_2,undefined4 param_3,int param_4,int param_5);
void FUN_0044d3b4(void);
void FUN_0044d3cc(int param_1,int param_2,int **param_3);
void FUN_0044d44c(int param_1);
void FUN_0044d500(void);
void FUN_0044d5a4(int param_1,LPCSTR param_2,LPCSTR param_3,UINT param_4);
void FUN_0044d6fc(int param_1,int param_2);
uint FUN_0044d7d4(int param_1,ushort param_2,ULONG_PTR param_3);
void FUN_0044d900(int param_1,ULONG_PTR param_2);
void FUN_0044d90c(int param_1,ushort param_2,ULONG_PTR param_3);
void FUN_0044d914(undefined4 param_1,int *param_2);
void FUN_0044d924(int param_1,char param_2);
void FUN_0044d964(void);
int * FUN_0044d9c8(int param_1);
void FUN_0044da4c(int param_1);
void FUN_0044db58(undefined4 param_1,uint param_2);
void FUN_0044dbf8(int *param_1,uint *param_2,undefined4 param_3);
void FUN_0044dc8c(byte param_1,undefined4 param_2,undefined4 param_3,int param_4);
void FUN_0044dce8(int param_1);
void FUN_0044dd70(int param_1,UINT param_2,undefined param_3);
void FUN_0044dda8(int param_1);
void FUN_0044ddc8(int param_1,int *param_2,int param_3);
void FUN_0044ded4(int param_1);
void FUN_0044df08(int param_1);
void FUN_0044df44(int param_1);
int FUN_0044df6c(char *param_1,int param_2,char param_3);
int FUN_0044df7c(void);
void FUN_0044e0d0(undefined *param_1,undefined4 param_2,undefined4 param_3,int param_4);
void FUN_0044e124(int param_1,int *param_2);
uint FUN_0044e4cc(int param_1,undefined4 param_2,int *param_3);
uint FUN_0044e55c(uint param_1,undefined4 param_2,uint param_3);
uint FUN_0044e584(uint param_1,undefined4 param_2,uint param_3);
HINSTANCE __stdcall ShellExecuteA(HWND hwnd,LPCSTR lpOperation,LPCSTR lpFile,LPCSTR lpParameters,LPCSTR lpDirectory,INT nShowCmd);
HRESULT __stdcall SHGetMalloc(IMalloc **ppMalloc);
void FUN_0044f84c(undefined param_1,undefined param_2,undefined param_3,int param_4);
void FUN_0044f910(int param_1,LPRECT param_2,undefined4 param_3,int param_4);
int * FUN_0044f970(int *param_1,char param_2,int *param_3);
void FUN_0044fa04(int *param_1,char param_2);
void FUN_0044fa50(int *param_1,int *param_2);
undefined4 FUN_0044fbb0(int *param_1);
void FUN_0044fc48(int *param_1,undefined4 param_2,uint param_3,undefined4 param_4,undefined4 param_5,undefined4 param_6,byte param_7);
void FUN_0044fcb4(int param_1,undefined4 param_2,undefined4 param_3);
int * FUN_0044ff8c(int *param_1,char param_2,int *param_3);
void FUN_00450014(int *param_1,UINT *param_2,undefined4 param_3);
void FUN_00450088(int param_1);
void FUN_00450114(int param_1,char param_2);
void FUN_00450124(int param_1,int param_2);
void FUN_00450134(int param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4,undefined4 param_5);
int * FUN_00450160(int *param_1,char param_2,int *param_3);
void FUN_004503a8(char param_1,undefined4 param_2,undefined4 param_3,int param_4);
void FUN_0045056c(int *param_1,undefined param_2);
void FUN_00450588(int *param_1,int param_2);
void FUN_00450634(int *param_1,int param_2);
undefined4 FUN_0045076c(int *param_1,undefined4 param_2,undefined4 param_3);
void FUN_00450798(void);
void FUN_00450e04(HWND param_1);
int * FUN_00450f04(int *param_1,char param_2,int *param_3);
void FUN_00450f4c(int *param_1,char param_2);
void FUN_0045102c(int *param_1);
undefined4 FUN_00451168(undefined param_1,undefined param_2,undefined param_3,HWND param_4,int param_5,WPARAM param_6,int param_7);
int * FUN_004511ec(int *param_1,char param_2,int *param_3);
undefined4 FUN_00451290(int *param_1,int param_2);
void FUN_004514bc(undefined4 *param_1,int *param_2);
void FUN_0045150c(int *param_1,undefined4 param_2);
char * FUN_00451738(undefined4 *param_1,int *param_2,undefined4 param_3,int param_4);
void FUN_00451780(undefined4 *param_1,undefined4 param_2,undefined4 param_3,int param_4);
void FUN_00451880(int param_1,int param_2);
void FUN_00451938(int param_1,LPRECT param_2);
void FUN_0045198c(int param_1,int *param_2);
void FUN_004519f4(int param_1,undefined *param_2);
bool FUN_00451a4c(int *param_1);
int FUN_00451a80(int param_1,int param_2);
void FUN_00451a88(int *param_1,LPSIZE param_2);
int * FUN_00451c40(int *param_1,char param_2,int *param_3);
void FUN_00451d74(uint *param_1,byte param_2,ushort param_3);
void FUN_004522e4(uint *param_1,byte param_2,ushort param_3,int param_4);
void FUN_00452304(uint *param_1,byte param_2,ushort param_3,int param_4,int param_5,int param_6);
void FUN_00452328(uint *param_1,byte param_2,ushort param_3,undefined4 *param_4,int param_5,int param_6,int param_7);
void FUN_004523dc(uint *param_1);
void FUN_004523e8(uint *param_1,int param_2,int param_3);
void FUN_00452728(void);
int * FUN_00452c90(int *param_1,char param_2,int *param_3);
void FUN_00452ce4(int param_1,char param_2);
void FUN_00452d34(int *param_1,int param_2);
int FUN_00452f94(int param_1,int *param_2,int *param_3);
void FUN_0045313c(undefined param_1,undefined param_2,undefined param_3,int param_4);
void FUN_0045334c(int *param_1,int *param_2,undefined4 param_3);
bool FUN_0045904c(void);
void FUN_00459078(void);
void FUN_004592b4(undefined4 *param_1);
void FUN_004592cc(int param_1);
void FUN_0045933c(int param_1,WPARAM param_2);
void FUN_004594ec(int param_1,WPARAM param_2);
void FUN_0045958c(int param_1,WPARAM param_2,undefined *param_3);
int * FUN_00459830(int *param_1,char param_2,int *param_3);
void FUN_004598f0(int *param_1,char param_2);
void FUN_00459970(int param_1);
void FUN_00459b18(int param_1,undefined4 param_2,RECT *param_3,byte param_4);
void FUN_00459b54(int *param_1,int param_2);
undefined4 FUN_00459b80(int param_1,undefined4 param_2);
void FUN_00459ba8(int *param_1);
void FUN_00459bc4(int *param_1);
void FUN_00459bf4(int *param_1,int param_2,byte param_3);
void FUN_00459c24(int param_1,int param_2);
void FUN_00459cb4(int param_1,char param_2);
void FUN_00459ed4(int *param_1,WPARAM param_2);
void FUN_0045a050(int *param_1);
void FUN_0045a090(int *param_1);
void FUN_0045a0b8(int *param_1);
void FUN_0045a35c(int *param_1,undefined4 param_2);
void FUN_0045a37c(int *param_1);
void FUN_0045a3d8(int *param_1,int param_2,undefined4 param_3);
void FUN_0045a41c(int *param_1,uint param_2);
int FUN_0045a61c(int param_1);
int FUN_0045a638(int param_1);
void FUN_0045a698(int *param_1,int *param_2);
void FUN_0045a6f4(int *param_1,int *param_2);
void FUN_0045a728(int param_1,int param_2);
void FUN_0045a7bc(int param_1,char param_2);
void FUN_0045a814(int param_1);
void FUN_0045a84c(int *param_1);
void FUN_0045a8f4(int param_1,byte param_2);
int * FUN_0045a934(int *param_1,char param_2,int *param_3);
void FUN_0045a9e8(int param_1);
void FUN_0045aa58(int *param_1);
void FUN_0045aa94(int *param_1,int *param_2);
void FUN_0045ab98(int *param_1,int param_2,WPARAM param_3);
int FUN_0045ac90(int param_1,int param_2,char param_3,char param_4);
void FUN_0045ad18(int param_1,undefined4 param_2,undefined4 param_3,undefined *param_4,undefined4 param_5);
undefined4 FUN_0045ad58(int param_1,int param_2);
undefined4 FUN_0045add4(int param_1,int param_2);
void FUN_0045ae24(int param_1,int param_2);
undefined4 FUN_0045ae3c(int param_1);
void FUN_0045ae8c(int param_1,int param_2);
void FUN_0045aeb0(int *param_1,int param_2);
void FUN_0045af1c(int param_1,undefined4 param_2);
void FUN_0045af34(int *param_1,int *param_2);
void FUN_0045af84(int *param_1,char param_2);
void FUN_0045afd8(int *param_1,int *param_2);
void FUN_0045b060(int param_1,int param_2);
void FUN_0045b0f8(int *param_1,int param_2);
void FUN_0045b154(int *param_1,int param_2,undefined4 param_3);
int FUN_0045b404(int *param_1,undefined4 *param_2);
void FUN_0045b494(int *param_1,int param_2);
void FUN_0045b514(int *param_1,int param_2);
int * FUN_0045b54c(int *param_1,char param_2,int *param_3);
void FUN_0045b598(int *param_1,undefined **param_2);
void FUN_0045b5f4(int param_1,char param_2);
void FUN_0045b620(int *param_1,undefined4 param_2,undefined4 param_3);
undefined4 FUN_0045b658(int param_1);
undefined4 FUN_0045b670(int param_1);
void FUN_0045b6ac(int param_1,char param_2);
void FUN_0045b6bc(int param_1,char param_2);
void FUN_0045b6cc(int param_1,char param_2);
void FUN_0045b6dc(int param_1,uint *param_2);
void FUN_0045b704(int param_1,int param_2);
int * FUN_0045b714(int *param_1,char param_2,int param_3);
void FUN_0045b758(int param_1);
void FUN_0045b764(int param_1,int param_2);
int * FUN_0045b7ac(int *param_1,char param_2,int *param_3);
void FUN_0045ba48(undefined4 param_1,int *param_2,char param_3,char param_4);
void FUN_0045bab0(int *param_1,undefined4 param_2,undefined4 param_3);
void FUN_0045bb14(int *param_1,uint *param_2);
void FUN_0045bb40(int *param_1,int param_2);
void FUN_0045bd8c(int param_1);
void FUN_0045bda8(int *param_1,int param_2,char param_3);
void FUN_0045bf30(int *param_1,char param_2,char param_3);
void FUN_0045c1f0(int param_1,char param_2);
void FUN_0045c234(int param_1,int param_2);
void FUN_0045c2d0(int param_1,int param_2);
void FUN_0045c2e4(int param_1,int param_2);
void FUN_0045c38c(undefined4 *param_1);
int * FUN_0045c3a4(int *param_1,char param_2,int param_3);
void FUN_0045c4a0(int param_1);
undefined4 FUN_0045c4b4(int param_1);
undefined4 FUN_0045c4bc(int param_1,int param_2);
uint FUN_0045c4fc(int param_1,undefined4 *param_2);
void FUN_0045c578(int param_1,undefined4 param_2);
bool FUN_0045c5d8(int param_1,undefined param_2);
void FUN_0045c664(int param_1,undefined4 param_2);
void FUN_0045c6b0(int param_1,undefined4 param_2);
void FUN_0045c6fc(int param_1,int param_2);
void FUN_0045c740(int param_1,int param_2);
undefined4 FUN_0045c788(int param_1,int param_2);
undefined4 FUN_0045c7b8(int param_1,char param_2);
void FUN_0045c804(int param_1,char param_2);
void FUN_0045c844(int param_1,undefined4 param_2,char param_3);
void FUN_0045c928(int param_1,undefined4 param_2);
void FUN_0045c934(int param_1,char param_2);
void FUN_0045c940(int param_1);
void FUN_0045c948(int param_1,char param_2);
void FUN_0045c95c(int param_1);
void FUN_0045c964(int param_1,char param_2);
void FUN_0045c998(int param_1);
void FUN_0045c9a0(int param_1,char param_2);
void FUN_0045c9e4(int param_1);
void FUN_0045c9ec(int param_1,char param_2);
uint FUN_0045ca20(int param_1);
void FUN_0045ca58(int param_1,char param_2);
void FUN_0045ca9c(int param_1);
void FUN_0045caa4(int param_1,byte param_2);
void FUN_0045cad4(int param_1);
void FUN_0045caf8(int param_1);
void FUN_0045cb1c(int param_1);
undefined4 FUN_0045cb40(undefined4 param_1,int param_2);
void FUN_0045cb50(int param_1);
int FUN_0045cb74(int param_1);
void FUN_0045cb94(int param_1);
int FUN_0045cbec(int param_1);
int FUN_0045cc1c(int param_1);
void FUN_0045cc40(int param_1,int param_2);
int FUN_0045ccb8(int param_1,int param_2);
int FUN_0045ccec(int param_1);
void FUN_0045cd08(int *param_1,undefined4 param_2,int param_3,char param_4,undefined4 param_5);
void FUN_0045ce84(int *param_1,int *param_2,char param_3);
bool FUN_0045d004(int param_1);
void FUN_0045d02c(int param_1,char param_2,undefined4 *param_3);
void FUN_0045d060(int param_1);
bool FUN_0045d06c(int param_1,undefined *param_2,undefined4 param_3);
void FUN_0045d0bc(int *param_1);
undefined4 FUN_0045d174(int param_1,int param_2);
void FUN_0045d19c(int param_1,int *param_2,undefined4 *param_3);
void FUN_0045d274(int param_1,int *param_2,undefined4 *param_3);
int * FUN_0045d324(int *param_1,char param_2,int param_3);
undefined4 FUN_0045d38c(int param_1);
void FUN_0045d3b0(int param_1);
void FUN_0045d3bc(int param_1,int *param_2,undefined4 param_3);
void FUN_0045d3e0(int param_1);
void FUN_0045d410(int param_1,int param_2,undefined4 *param_3);
void FUN_0045d418(int param_1,int param_2,undefined4 *param_3,undefined4 param_4);
void FUN_0045d42c(int param_1,int param_2,undefined4 *param_3);
void FUN_0045d434(int param_1,int param_2);
void FUN_0045d488(int param_1,int param_2,undefined4 *param_3,undefined4 param_4);
void FUN_0045d4b4(int param_1,int param_2);
void FUN_0045d4d4(int param_1,int param_2,undefined4 *param_3,char param_4,undefined4 param_5);
void FUN_0045d5fc(undefined4 param_1,int param_2,undefined4 *param_3);
void FUN_0045d620(int param_1,undefined4 param_2,undefined4 param_3,char param_4,undefined4 *param_5);
void FUN_0045d694(int param_1);
void FUN_0045d6b0(int param_1,int param_2);
undefined4 FUN_0045d798(int param_1,undefined4 param_2);
void FUN_0045d7c8(int *param_1,undefined **param_2,undefined4 param_3);
uint FUN_0045d858(undefined param_1,undefined param_2,undefined param_3,int param_4);
void FUN_0045d940(int param_1,int *param_2);
void FUN_0045d990(int param_1,int *param_2);
void FUN_0045da00(int param_1,int *param_2);
void FUN_0045da70(int param_1,int *param_2);
void FUN_0045dacc(int param_1);
void FUN_0045dfe4(int *param_1,UINT *param_2,undefined4 param_3);
void FUN_0045e0e4(int *param_1);
void FUN_0045e0f8(uint param_1,undefined4 param_2);
void FUN_0045e114(int *param_1);
uint FUN_0045e164(int *param_1);
uint FUN_0045e1c0(int *param_1,undefined *param_2,undefined4 param_3);
undefined4 FUN_0045e288(int *param_1,undefined4 param_2,undefined4 param_3);
void FUN_0045e2c0(int *param_1,WPARAM param_2);
void FUN_0045e2e4(int *param_1);
void FUN_0045e2f8(int param_1);
undefined4 FUN_0045e340(int *param_1);
void FUN_0045e370(int *param_1,int param_2);
void FUN_0045e398(int *param_1);
int FUN_0045e3c0(int *param_1);
void FUN_0045e408(int *param_1,int param_2);
int FUN_0045e42c(int *param_1);
void FUN_0045e464(int *param_1,int param_2);
undefined4 FUN_0045e498(int param_1,int param_2);
void FUN_0045e4c0(int *param_1,int param_2);
void FUN_0045ef94(int param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4);
void FUN_0045f03c(int *param_1,int *param_2,undefined4 param_3,undefined4 param_4,undefined4 param_5);
void FUN_0045f2a8(int *param_1,LPARAM param_2,WPARAM param_3);
void FUN_0045f2d0(int *param_1,int *param_2);
void FUN_0045f36c(int *param_1,int param_2);
void FUN_0045f3d4(int *param_1,int param_2);
bool FUN_0045f6f8(int param_1,char param_2,char param_3);
void FUN_0045f874(undefined4 param_1,int *param_2,undefined4 param_3,undefined4 param_4);
int * FUN_0045f888(int *param_1,char param_2,int *param_3);
void FUN_0045fb30(int *param_1,int param_2);
void FUN_0045fb88(int *param_1,undefined4 param_2,undefined4 param_3);
undefined4 FUN_0045fcb8(int *param_1,int param_2);
void FUN_0045fce8(int *param_1,int *param_2);
void FUN_0045fef4(int *param_1,int *param_2);
void FUN_0045ff48(int *param_1,int param_2,byte param_3);
uint FUN_0045ff98(int *param_1);
void FUN_0045ffd0(int *param_1,short param_2);
void FUN_00460018(int *param_1,short param_2);
void FUN_00460060(int *param_1,int param_2);
void FUN_004600bc(int *param_1,uint param_2);
void FUN_00460208(int *param_1,char param_2);
void FUN_00460244(int *param_1,char param_2);
void FUN_00460280(int *param_1,char param_2);
void FUN_004602bc(int *param_1,char param_2);
int * FUN_004602f8(int *param_1,char param_2,int *param_3);
void FUN_00460488(undefined param_1,undefined param_2,undefined param_3,int param_4);
void FUN_0046057c(int param_1);
void FUN_004606a0(int param_1,uint *param_2);
undefined4 FUN_004606c8(int param_1);
void FUN_004606fc(int param_1,int param_2);
void FUN_00460728(int param_1,char param_2);
void FUN_00460758(int param_1,undefined4 param_2,undefined4 param_3);
void FUN_00460784(int param_1,int param_2);
void FUN_00460794(int param_1,int param_2);
void FUN_004607a4(int param_1,int param_2);
int * FUN_0046084c(int *param_1,char param_2,int param_3);
void FUN_00460890(int param_1,int param_2);
void FUN_004608d4(int *param_1);
void FUN_00460b10(int param_1,int param_2);
int * FUN_00460c24(int *param_1,char param_2,int param_3);
void FUN_00460cec(int param_1);
void FUN_00460cf8(int param_1,int param_2);
void FUN_00460d3c(int *param_1,int param_2,undefined4 *param_3);
void FUN_00460d98(int param_1,int param_2);
void FUN_00460dd0(int param_1,int param_2);
void FUN_00460de4(int param_1,int param_2,int param_3);
int * FUN_00460df0(int *param_1,char param_2,int param_3);
undefined4 FUN_00460eac(int param_1);
void FUN_00460eb4(int *param_1);
void FUN_00460ed8(int param_1);
uint FUN_00460eec(int param_1);
void FUN_00460f30(int param_1,uint param_2);
void FUN_00460f70(int param_1);
char FUN_00460f8c(int param_1,undefined4 *param_2);
void FUN_0046102c(int param_1,undefined4 param_2);
uint FUN_00461058(int param_1,undefined4 param_2);
void FUN_004610c0(int param_1,undefined4 param_2,char param_3);
void FUN_00461130(int param_1,int param_2,int param_3);
void FUN_00461260(int param_1,int param_2);
undefined4 FUN_00461364(int param_1,int param_2);
void FUN_0046138c(int param_1,int param_2);
undefined4 FUN_004613a0(int param_1);
void FUN_004613bc(int param_1,byte param_2,undefined4 *param_3);
void FUN_004613ec(int param_1,int param_2);
void FUN_004613f8(int param_1,int param_2,int param_3);
int * FUN_00461450(int *param_1,char param_2,int param_3);
undefined4 FUN_004614b8(int param_1);
undefined4 FUN_004614f8(int param_1);
void FUN_0046151c(int param_1);
undefined4 FUN_00461528(int param_1,undefined4 param_2);
void FUN_004615a8(int param_1,undefined4 param_2);
void FUN_004615d0(int param_1,WPARAM param_2);
void FUN_004615ec(int param_1);
void FUN_0046160c(int param_1);
void FUN_00461624(int param_1,char param_2);
void FUN_004617e8(int param_1);
uint FUN_0046185c(undefined param_1,undefined param_2,undefined param_3,int param_4);
int FUN_00461b3c(int param_1);
void FUN_00461df4(undefined4 param_1,undefined4 param_2,undefined4 param_3,undefined4 *param_4);
int * FUN_00461e18(int *param_1,char param_2,int param_3);
void FUN_00461e8c(int param_1,char param_2);
void FUN_00461ea0(int param_1,char param_2);
void FUN_00461eb4(int param_1,char param_2);
int * FUN_00461f34(int *param_1,char param_2,int *param_3);
void FUN_00462340(undefined4 param_1,undefined4 param_2,undefined4 param_3,int param_4);
void FUN_004623f4(int *param_1);
void FUN_004625dc(int *param_1,undefined4 param_2,undefined4 param_3);
void FUN_00462650(int *param_1,LPARAM param_2,WPARAM param_3);
void FUN_00462678(int *param_1,int *param_2);
void FUN_00462754(undefined param_1,undefined param_2,undefined param_3,int param_4);
void FUN_00462a88(int *param_1,WPARAM param_2,LPARAM param_3);
void FUN_00462aa8(int *param_1);
void FUN_00462ba4(int param_1,undefined4 param_2,uint param_3);
void FUN_00462c30(int param_1,undefined4 param_2,uint param_3);
void FUN_00462cb0(int *param_1,char param_2);
void FUN_00462dfc(int param_1,char param_2);
void FUN_00462e10(int param_1,char param_2);
void FUN_00462e38(int param_1,char param_2);
void FUN_00462e4c(int *param_1);
void FUN_00462e6c(int *param_1);
void FUN_00462ea0(int *param_1,WPARAM param_2);
void FUN_00462ed0(int *param_1);
uint FUN_00463138(uint param_1);
uint FUN_00463144(uint param_1);
void FUN_00463150(int *param_1);
void FUN_00463190(int param_1,char param_2);
int * FUN_004631e4(int *param_1,char param_2);
void FUN_00463268(int *param_1,int *param_2);
byte FUN_0046339c(uint param_1);
void FUN_004633e8(int *param_1,uint *param_2);
void FUN_00463518(int *param_1);
undefined4 FUN_0046352c(uint param_1);
uint FUN_00463550(uint param_1);
void FUN_0046419c(int *param_1,int param_2,int param_3);
void FUN_00464230(int param_1,undefined4 param_2,undefined4 *param_3);
void FUN_004646a8(int *param_1,int *param_2,undefined4 param_3,char param_4,undefined4 param_5);
bool FUN_0046474c(int *param_1);
void FUN_0046477c(int *param_1,char param_2);
void FUN_004647b4(int *param_1,LPARAM param_2);
undefined4 FUN_004647cc(int *param_1);
void FUN_00464804(int *param_1,int param_2);
void FUN_00464874(int *param_1,int param_2);
void FUN_004648ec(int *param_1,int param_2,uint param_3);
void FUN_004649a8(int param_1,int param_2);
void FUN_004649b4(int *param_1);
int FUN_004649cc(int *param_1);
void FUN_004649f0(int *param_1,int param_2);
void FUN_00464a34(int param_1,undefined4 param_2);
undefined4 FUN_00464a54(int *param_1,int param_2,undefined param_3,byte param_4);
undefined4 FUN_00464b28(int *param_1,undefined4 *param_2,byte param_3);
undefined4 FUN_00464b90(int *param_1,undefined4 param_2,undefined4 param_3);
void FUN_00464bf4(int *param_1,byte param_2);
void FUN_00464c14(int *param_1);
void FUN_00464c54(int *param_1,int param_2);
void FUN_00464d9c(int *param_1,int param_2);
void FUN_00464f00(int *param_1,undefined4 param_2,undefined4 param_3);
void FUN_004650c8(int *param_1,int param_2);
bool FUN_004651f0(int param_1,char param_2,char param_3);
uint FUN_004653c0(uint param_1,undefined4 param_2,uint param_3,undefined4 param_4,ushort param_5);
void FUN_00465438(int param_1,int param_2,LONG *param_3,ushort param_4);
void FUN_004654b0(int param_1,int param_2,int param_3,undefined4 param_4);
void FUN_004654f4(int *param_1);
uint FUN_00465660(int *param_1,int param_2);
int FUN_00465868(int param_1,int param_2);
void FUN_004659c8(int *param_1,byte param_2,uint param_3,int param_4);
void FUN_00465b30(int *param_1,int param_2,int param_3,int *param_4,int *param_5);
void FUN_00465d1c(int *param_1);
byte FUN_00465f14(int *param_1);
void FUN_00466000(int *param_1,uint param_2);
void FUN_00466068(int *param_1);
void FUN_004660d8(int *param_1);
void FUN_00466130(int param_1,byte param_2);
void FUN_00466190(int param_1,int param_2,undefined4 param_3);
void FUN_004661cc(int *param_1,int param_2);
void FUN_00466230(int param_1,byte param_2);
void FUN_004662bc(int *param_1,int param_2,undefined4 param_3);
void FUN_004663f0(int *param_1,char param_2);
int FUN_00466428(int param_1);
void FUN_00466478(int param_1);
undefined4 FUN_004664e8(int param_1);
undefined4 FUN_00466508(int param_1);
void FUN_00466528(int *param_1,int *param_2,char param_3);
int * FUN_00466624(int *param_1,char param_2,int *param_3);
undefined4 FUN_004669ac(undefined param_1,undefined param_2,undefined param_3,int param_4);
void FUN_00466a1c(int *param_1,uint param_2,int param_3);
void FUN_00466bb0(int *param_1,undefined4 param_2);
void FUN_00466ce8(int *param_1,int param_2);
void FUN_00466d60(uint param_1,uint *param_2,uint *param_3);
void FUN_00466e38(int *param_1,int param_2);
void FUN_00466e4c(int *param_1,int param_2);
void FUN_00466e60(int *param_1,int *param_2);
void FUN_00466f1c(int *param_1,int *param_2);
void FUN_00466f9c(int param_1,undefined4 param_2,int param_3,undefined4 param_4);
void FUN_0046718c(int param_1,undefined4 param_2,int param_3,undefined4 param_4);
uint FUN_00467390(int *param_1,int param_2);
void FUN_00467498(int *param_1,int param_2);
void FUN_00467594(int *param_1);
void FUN_00467698(int param_1,undefined4 param_2);
void FUN_004676f8(int param_1);
void FUN_0046773c(int *param_1,undefined4 param_2,undefined4 param_3);
void FUN_0046776c(int param_1,int param_2);
undefined4 FUN_00467784(int param_1);
void FUN_004677cc(int *param_1,undefined4 param_2,undefined4 param_3);
void FUN_00467844(int *param_1,undefined4 param_2,undefined4 param_3,int param_4);
void FUN_0046793c(int param_1,int *param_2,undefined4 param_3);
void FUN_00467a38(int *param_1);
void FUN_00467ad8(int *param_1,undefined4 param_2);
void FUN_00467b04(int *param_1,int param_2);
void FUN_00467b7c(int *param_1,undefined4 param_2);
void FUN_00467ba8(int *param_1,int param_2);
void FUN_00467c20(int *param_1,undefined4 param_2);
void FUN_00467c4c(int *param_1,int param_2);
void FUN_00467cb4(int *param_1);
void FUN_00467ce4(int *param_1);
void FUN_00467d10(int *param_1,int param_2);
void FUN_00467dc0(int param_1,int param_2,undefined4 param_3,undefined *param_4,undefined4 param_5);
void FUN_00467e9c(int param_1);
void FUN_00467ea4(int param_1);
void FUN_00467eac(int *param_1);
void FUN_00467ee4(int param_1);
uint FUN_00467ef4(int param_1,uint param_2,int param_3,int param_4);
uint FUN_00468040(int param_1,uint param_2,int param_3,int param_4);
void FUN_00468108(int *param_1,int param_2);
void FUN_0046828c(int param_1,int param_2);
void FUN_00468330(int *param_1,int param_2);
void FUN_00468474(int *param_1,int *param_2,undefined4 param_3,int param_4);
int FUN_0046867c(int param_1,undefined4 param_2,undefined4 param_3,int param_4);
int FUN_00468888(undefined4 param_1,int *param_2,undefined4 param_3,int param_4);
undefined4 FUN_0046899c(int *param_1,undefined4 param_2,undefined4 param_3,int param_4);
uint FUN_00468a30(int *param_1,int *param_2,int **param_3);
void FUN_00468ce8(int *param_1,int param_2);
void FUN_00468d90(int *param_1);
void FUN_00468de4(int param_1,int param_2);
void FUN_00468df8(int param_1);
undefined4 FUN_0046936c(int param_1,undefined4 param_2,undefined4 param_3,int param_4);
void FUN_00469420(int param_1,undefined4 param_2,undefined4 param_3,int param_4);
void FUN_004696d0(int param_1,undefined2 param_2);
bool FUN_00469790(int param_1,char param_2,char param_3);
int * FUN_004698f8(char param_1);
LRESULT FUN_004699a4(undefined param_1,undefined param_2,undefined param_3,int param_4,WPARAM param_5,HWND *param_6);
void FUN_00469c74(void);
void FUN_00469cac(void);
void FUN_00469ce8(undefined4 param_1,undefined4 param_2,undefined4 param_3,int param_4,WPARAM param_5,int *param_6);
void FUN_00469d64(void);
void FUN_00469d88(void);
void FUN_00469dac(int param_1);
uint FUN_00469e58(int *param_1,int *param_2);
undefined4 FUN_0046a124(undefined param_1,undefined param_2,undefined param_3,int param_4);
void FUN_0046a190(int *param_1,int param_2);
void FUN_0046a29c(int *param_1,int param_2);
void FUN_0046a314(int *param_1);
bool FUN_0046a360(int *param_1,int param_2,undefined4 param_3);
int * FUN_0046a82c(int *param_1,char param_2,undefined4 *param_3);
uint FUN_0046a988(int *param_1,undefined4 param_2,undefined4 param_3,undefined param_4);
void FUN_0046a9b4(undefined **param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4,undefined4 param_5);
void FUN_0046aa6c(undefined **param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4,undefined4 param_5);
void FUN_0046ab24(undefined **param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4,undefined4 param_5);
void FUN_0046abdc(undefined **param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4,undefined4 param_5);
void FUN_0046ac94(int *param_1,undefined4 param_2,undefined *param_3,undefined4 param_4,undefined4 param_5);
void FUN_0046ae4c(int param_1,undefined *param_2,undefined *param_3,int *param_4,undefined *param_5);
void FUN_0046b434(undefined4 param_1);
undefined4 FUN_0046b460(char *param_1);
undefined4 FUN_0046b474(int param_1);
int * FUN_0046b49c(int *param_1,char param_2,undefined4 param_3);
void FUN_0046b50c(int param_1);
void FUN_0046b53c(int param_1,HKEY param_2);
void FUN_0046b568(int param_1,undefined4 param_2,undefined4 *param_3);
int FUN_0046b58c(int param_1,char param_2);
void FUN_0046b5a0(int param_1,int param_2,char param_3);
uint FUN_0046b6c4(int param_1,undefined *param_2,undefined4 *param_3);
undefined4 FUN_0046b714(int param_1,undefined *param_2);
void FUN_0046b73c(int param_1,undefined *param_2,int *param_3);
DWORD FUN_0046b7b4(int param_1,undefined *param_2,LPBYTE param_3,undefined *param_4,DWORD param_5);
void FUN_0046b828(int param_1,int param_2);
uint FUN_0046b8c0(int param_1,int param_2);
int * FUN_0046befc(int *param_1,char param_2,int *param_3);
void FUN_0046c7dc(int *param_1,int param_2);
undefined4 FUN_0046c8d0(int param_1,int param_2);
void FUN_0046d15c(undefined *param_1,undefined *param_2,undefined *param_3,INT param_4);
int FUN_0046d1bc(HDC param_1,LPCSTR param_2,int param_3,char param_4,COLORREF param_5,byte param_6,ushort param_7,LPRECT param_8);
int * FUN_0046d2c4(int *param_1,char param_2,int *param_3);
void FUN_0046d388(int *param_1,LPRECT param_2,ushort param_3);
void FUN_0046d660(int *param_1);
uint FUN_0046d79c(uint param_1);
void FUN_0046d7a8(int *param_1,int param_2,undefined4 param_3);
void FUN_0046d7e4(int *param_1,char param_2);
void FUN_0046d84c(int *param_1,int param_2,byte param_3);
void FUN_0046d8d8(int *param_1);
void FUN_0046d8ec(int *param_1,int param_2);
void FUN_0046d9b8(int *param_1,undefined4 param_2,undefined4 param_3);
void FUN_0046da04(int param_1);
void FUN_0046dca4(void);
void FUN_0046dcdc(void);
void FUN_0046e0d4(int *param_1,int param_2);
void FUN_0046e744(void);
void FUN_0046e97c(int param_1,int *param_2);
int * FUN_0046ea44(int *param_1,char param_2,int *param_3);
void FUN_0046eacc(int param_1);
void FUN_0046ebf4(int param_1,int param_2);
void FUN_0046ec90(int param_1,int param_2);
void FUN_0046ecb4(int param_1,int param_2);
void FUN_0046ecd8(int param_1,char *param_2);
undefined4 FUN_0046ef30(undefined4 param_1,char param_2);
void FUN_0046ef4c(void);
void FUN_0046f110(undefined param_1,undefined param_2,undefined param_3,int param_4);
LONG FUN_0046f124(undefined param_1,undefined param_2,undefined param_3,int *param_4);
void FUN_0046f18c(void);
void FUN_0046f6a8(HWND param_1,int *param_2,int *param_3);
void FUN_0046f6e8(HGLOBAL param_1,int *param_2);
undefined4 FUN_0046f9b8(undefined param_1,undefined param_2,undefined param_3,int *param_4,ushort param_5,int param_6,uint param_7,undefined4 *param_8);
undefined4 FUN_0046fafc(undefined param_1,undefined param_2,undefined param_3,int *param_4);
undefined4 FUN_0046fb58(undefined param_1,undefined param_2,undefined param_3,int *param_4,undefined param_5,undefined2 param_6,int param_7,undefined4 param_8,undefined4 *param_9);
void FUN_0046fc14(int param_1,byte param_2,undefined4 *param_3,undefined4 param_4);
int * FUN_0046fc4c(int *param_1,char param_2,int *param_3);
void FUN_0046fd70(int *param_1,char param_2);
void FUN_0046fdb0(LPDROPTARGET param_1,IDropTargetVtbl *param_2);
void FUN_0046fe70(int param_1);
void FUN_0046ff20(int param_1,char param_2);
undefined4 FUN_00470160(undefined4 param_1,undefined4 param_2,undefined4 param_3);
int FUN_0047029c(int param_1,undefined4 param_2,undefined4 param_3);
uint FUN_004702fc(int param_1);
void FUN_00470314(int param_1);
void FUN_00470330(int *param_1);
BOOL __stdcall GetOpenFileNameA(LPOPENFILENAMEA param_1);
BOOL __stdcall GetSaveFileNameA(LPOPENFILENAMEA param_1);
void FUN_00470814(undefined param_1,undefined param_2,undefined param_3,undefined4 *param_4);
int * FUN_00470858(int *param_1,char param_2,int *param_3);
bool FUN_004708a0(int *param_1);
undefined4 FUN_004708d8(void);
int * FUN_0047090c(int *param_1,char param_2,int *param_3);
undefined FUN_0047094c(int *param_1);
void FUN_00470978(void);
void FUN_00470e60(int param_1,undefined4 param_2);
void FUN_00470f10(int param_1,int param_2);
void FUN_004710a0(int param_1,int param_2,undefined4 param_3,int *param_4,int *param_5);
void FUN_004714b4(void);
void FUN_004715ac(undefined param_1,undefined param_2,undefined param_3,double param_4,undefined4 param_5);
void FUN_004716c8(undefined param_1,undefined param_2,undefined param_3,double param_4,double param_5,double param_6);
void FUN_004717ac(void);
void FUN_00471808(undefined param_1,undefined param_2,undefined param_3,double param_4,double param_5);
void FUN_0047183c(undefined param_1,undefined param_2,undefined param_3,double param_4,double param_5);
void FUN_00471870(uint param_1,double *param_2,double *param_3,double *param_4);
void FUN_00471a24(uint param_1,undefined4 *param_2,undefined4 *param_3,undefined4 *param_4);
void FUN_00471a80(void);
undefined4 FUN_00471b14(uint param_1,undefined4 param_2,byte param_3,char param_4);
void FUN_00471b90(void);
int * FUN_00472420(int *param_1,char param_2,int *param_3);
void FUN_004725b0(int param_1);
void FUN_00472680(int *param_1,undefined4 param_2,undefined4 param_3);
void FUN_00472724(int *param_1);
void FUN_0047274c(int *param_1);
void FUN_00472784(int *param_1,int param_2);
void FUN_00472868(int *param_1);
void FUN_004728bc(int *param_1);
void FUN_00472998(int *param_1,undefined4 param_2,byte param_3,undefined4 param_4,undefined4 param_5);
void FUN_00472a04(int *param_1,byte param_2,uint param_3,undefined4 param_4);
void FUN_00472ab8(int *param_1);
void FUN_00472ae4(int *param_1);
void FUN_00472e28(int *param_1);
void FUN_00473034(int *param_1);
void FUN_0047306c(int param_1);
void FUN_00473088(void);
void FUN_00473124(undefined param_1,undefined param_2,undefined param_3,undefined4 param_4);
void FUN_0047313c(undefined param_1,undefined param_2,undefined param_3,undefined4 param_4,undefined4 param_5,undefined4 param_6);
void FUN_0047315c(undefined param_1,undefined param_2,undefined param_3,undefined4 param_4,undefined4 param_5);
void FUN_00473178(undefined param_1,undefined param_2,undefined param_3,undefined4 param_4,undefined4 param_5,undefined4 param_6);
void FUN_00473198(void);
void FUN_004731a0(undefined param_1,undefined param_2,undefined param_3,undefined4 param_4,undefined4 param_5,undefined4 param_6);
undefined FUN_004731c0(void);
void FUN_004731c8(void);
void FUN_00473590(void);
void FUN_004735d8(void);
void FUN_00473c48(int *param_1,char param_2);
void FUN_00473d34(undefined4 param_1,undefined4 *param_2);
void FUN_00473d50(void);
void FUN_00473ee0(int *param_1);
undefined4 FUN_00474254(int *param_1);
void FUN_004742ac(int *param_1,char param_2);
void FUN_00474984(int *param_1);
void FUN_0047498c(undefined4 param_1,undefined4 *param_2,undefined4 *param_3);
int FUN_004749ec(int param_1,undefined4 *param_2);
void FUN_00474ac8(int *param_1,int *param_2,undefined4 param_3,int *param_4,int param_5);
MMRESULT __stdcall midiInAddBuffer(HMIDIIN hmi,LPMIDIHDR pmh,UINT cbmh);
MMRESULT __stdcall midiInClose(HMIDIIN hmi);
MMRESULT __stdcall midiInGetDevCapsA(UINT_PTR uDeviceID,LPMIDIINCAPSA pmic,UINT cbmic);
MMRESULT __stdcall midiInGetErrorTextA(MMRESULT mmrError,LPSTR pszText,UINT cchText);
UINT __stdcall midiInGetNumDevs(void);
MMRESULT __stdcall midiInOpen(LPHMIDIIN phmi,UINT uDeviceID,DWORD_PTR dwCallback,DWORD_PTR dwInstance,DWORD fdwOpen);
MMRESULT __stdcall midiInPrepareHeader(HMIDIIN hmi,LPMIDIHDR pmh,UINT cbmh);
MMRESULT __stdcall midiInReset(HMIDIIN hmi);
MMRESULT __stdcall midiInUnprepareHeader(HMIDIIN hmi,LPMIDIHDR pmh,UINT cbmh);
MMRESULT __stdcall midiOutClose(HMIDIOUT hmo);
MMRESULT __stdcall midiOutGetDevCapsA(UINT_PTR uDeviceID,LPMIDIOUTCAPSA pmoc,UINT cbmoc);
MMRESULT __stdcall midiOutGetErrorTextA(MMRESULT mmrError,LPSTR pszText,UINT cchText);
UINT __stdcall midiOutGetNumDevs(void);
MMRESULT __stdcall midiOutLongMsg(HMIDIOUT hmo,LPMIDIHDR pmh,UINT cbmh);
MMRESULT __stdcall midiOutOpen(LPHMIDIOUT phmo,UINT uDeviceID,DWORD_PTR dwCallback,DWORD_PTR dwInstance,DWORD fdwOpen);
MMRESULT __stdcall midiOutPrepareHeader(HMIDIOUT hmo,LPMIDIHDR pmh,UINT cbmh);
MMRESULT __stdcall midiOutShortMsg(HMIDIOUT hmo,DWORD dwMsg);
MMRESULT __stdcall midiOutUnprepareHeader(HMIDIOUT hmo,LPMIDIHDR pmh,UINT cbmh);
LPVOID FUN_00474f7c(uint param_1,HGLOBAL *param_2);
void FUN_00474fb8(HGLOBAL param_1);
HGLOBAL * FUN_00474fd0(uint param_1,undefined4 param_2,HGLOBAL param_3);
void FUN_0047503c(HGLOBAL *param_1);
undefined4 FUN_0047505c(int param_1,undefined4 *param_2);
undefined4 FUN_0047507c(int param_1);
void FUN_004750a0(void);
int * FUN_00475230(int *param_1,char param_2,uint param_3);
void FUN_004752dc(void);
undefined4 FUN_0047534c(undefined param_1,undefined param_2,undefined param_3,int param_4,undefined4 *param_5);
void FUN_00475394(undefined param_1,undefined param_2,undefined param_3,undefined param_4,int param_5,int param_6,int param_7,undefined4 param_8);
void FUN_004757ec(undefined4 param_1,uint param_2,int *param_3);
void FUN_00475968(int param_1,ushort param_2);
void FUN_00475c74(int param_1,undefined4 param_2,undefined4 param_3);
void FUN_00475d50(int param_1);
void FUN_00475e14(int param_1);
void FUN_00475ec4(uint param_1,undefined4 param_2,HGLOBAL param_3);
void FUN_00476024(int param_1);
uint FUN_0047616c(int param_1);
void FUN_00476180(int param_1);
void FUN_004762c8(int param_1,int *param_2);
int * FUN_004764f8(int *param_1,char param_2,int *param_3);
void FUN_0047659c(undefined4 param_1,uint param_2,int *param_3);
void FUN_0047664c(int param_1,uint param_2);
void FUN_0047746c(int *param_1,char param_2);
void FUN_004774c4(int *param_1,int param_2);
void FUN_0047751c(int *param_1,int param_2);
void FUN_004775ac(int param_1);
void FUN_00477620(int *param_1);
void FUN_00477674(int *param_1);
void FUN_00478118(int param_1,int *param_2);
void FUN_00478174(int *param_1);
void FUN_004789f4(int param_1);
void FUN_00478c10(int *param_1,undefined4 param_2,undefined4 param_3);
void FUN_00478d64(int *param_1);
void FUN_00478de0(int *param_1);
void FUN_00479274(void);
void FUN_00479718(int *param_1,undefined4 *param_2);
void FUN_004799c8(int param_1,undefined4 param_2,short *param_3);
void FUN_00479a64(void);
void FUN_00479da0(int param_1,int param_2,int param_3);
void FUN_00479ea4(int *param_1);
int * FUN_0047a820(int *param_1,char param_2,undefined4 param_3);
void FUN_0047a874(int param_1,uint param_2);
void FUN_0047a8fc(int param_1);
void FUN_0047a92c(void);
undefined4 FUN_0047c710(void);
void FUN_0047c82c(int param_1);
void FUN_0047c864(int param_1);
void FUN_0047d478(int param_1);
void FUN_00481180(int param_1);
void FUN_00481280(int param_1,char param_2,uint param_3);
void FUN_00481304(int param_1,undefined4 param_2,undefined4 param_3);
void FUN_00481320(int param_1,int param_2);
void FUN_00481374(int param_1);
void FUN_00481644(int param_1);
void FUN_004816c4(int param_1,undefined4 param_2,undefined4 param_3);
void FUN_00481870(int param_1);
void FUN_004818d0(int param_1);
void FUN_00481958(int param_1);
void FUN_00481b6c(int *param_1,int param_2,uint param_3,undefined param_4,undefined param_5,undefined param_6,undefined param_7,undefined param_8,undefined param_9,undefined param_10,undefined1 param_11,undefined1 param_12,undefined1 param_13);
void FUN_00481f10(int *param_1,undefined4 *param_2);
void FUN_004825a4(int param_1,int param_2);
void FUN_00482624(int param_1);
void FUN_00482680(int param_1,int param_2);
int FUN_00483140(int param_1,byte param_2);
int FUN_0048316c(int param_1,int param_2);
int FUN_00483190(int param_1,byte param_2);
int FUN_004831bc(int param_1,int param_2);
void FUN_004831e0(int param_1);
void FUN_004832f8(int param_1);
void FUN_004833bc(int param_1);
void FUN_00483568(int param_1);
void FUN_0048362c(int param_1);
void FUN_00483808(int param_1);
void FUN_004838ac(int param_1,uint *param_2);
void FUN_00483948(int param_1,undefined *param_2);
void FUN_0048398c(int param_1);
void FUN_004839c4(int param_1,undefined4 *param_2);
void FUN_00483b38(int param_1,undefined *param_2);
void FUN_00483c54(int param_1,uint *param_2);
void FUN_00483cc8(int param_1,undefined *param_2);
void FUN_00483d08(int param_1,undefined4 *param_2);
void FUN_00483e64(int param_1,undefined *param_2);
void FUN_00483f38(int param_1,undefined4 *param_2);
void FUN_00484084(int param_1,undefined *param_2);
void FUN_00484150(int param_1,uint *param_2,undefined4 param_3);
void FUN_0048422c(int param_1,undefined *param_2);
void FUN_00484288(int param_1,uint *param_2,undefined4 param_3);
void FUN_0048438c(int param_1,undefined *param_2);
void FUN_00484410(int param_1,uint param_2,undefined4 param_3);
void FUN_004844a0(int param_1,undefined *param_2);
void FUN_004844c4(int param_1,uint *param_2,undefined4 param_3);
void FUN_00484574(int param_1,undefined *param_2);
void FUN_004845a8(int param_1,uint *param_2,undefined4 param_3);
void FUN_00484684(int param_1,undefined *param_2);
void FUN_004846e0(int param_1,uint *param_2,undefined4 param_3);
void FUN_004847bc(int param_1,undefined *param_2);
void FUN_00484818(int param_1,uint *param_2,WPARAM param_3,WPARAM param_4);
void FUN_0048758c(int param_1,int param_2);
void FUN_0048d860(int param_1,int param_2);
void FUN_0048e304(undefined4 param_1,int param_2,char *param_3,char *param_4);
int FUN_0048e328(undefined4 param_1,uint param_2,byte param_3);
void FUN_0048e338(int param_1);
void FUN_0048e434(int param_1,int param_2);
void FUN_0048f1fc(int param_1);
bool FUN_004901d0(undefined4 param_1,undefined4 param_2,uint param_3,undefined param_4,undefined param_5,undefined param_6,undefined param_7,undefined param_8,undefined param_9,undefined param_10,undefined1 param_11);
void FUN_00490218(int param_1,int param_2);
void FUN_00490e88(int *param_1);
void FUN_00491260(int param_1);
void FUN_00491530(int param_1);
void FUN_00491574(int param_1);
void FUN_004915f8(int param_1);
void FUN_004916b4(int *param_1);
void FUN_00491804(int param_1);
void FUN_00491948(int param_1);
void FUN_00491b44(int param_1);
void FUN_00491dec(int param_1,int param_2);
void FUN_00491ec4(int param_1);
void FUN_00492040(int param_1);
int * FUN_00492e24(int *param_1,char param_2,int *param_3);
void FUN_00492eb4(int param_1,undefined4 *param_2);
void FUN_0049300c(int param_1,undefined4 param_2,int *param_3);
void FUN_004930f8(int param_1,int param_2,int *param_3);
void FUN_0049322c(int *param_1,undefined4 *param_2,undefined4 param_3,int param_4);
void FUN_004932f4(int param_1);
void FUN_004934ac(undefined4 *param_1,undefined4 *param_2,undefined4 param_3,int *param_4,int *param_5);
void entry(void);

