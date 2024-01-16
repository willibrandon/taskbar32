using Windows.Win32.UI.Shell;

namespace taskbar32;

public enum TaskbarProgressState
{
    NoProgress = TBPFLAG.TBPF_NOPROGRESS,
    Indeterminate = TBPFLAG.TBPF_INDETERMINATE,
    Normal = TBPFLAG.TBPF_NORMAL,
    Error = TBPFLAG.TBPF_ERROR,
    Paused = TBPFLAG.TBPF_PAUSED
}