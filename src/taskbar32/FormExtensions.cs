using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.UI.Controls;
using Windows.Win32.UI.Shell;
using Windows.Win32.UI.WindowsAndMessaging;

namespace taskbar32;

/// <summary>
///  Windows taskbar extension methods for <see cref="Form"/>.
/// </summary>
public static class FormExtensions
{
    /// <summary>
    ///  Activates an item on the taskbar. The window is not actually activated; the window's item on the taskbar is merely displayed as
    ///  active.
    /// </summary>
    public static void ActivateTab(this Form form)
    {
        ITaskbarList4 taskbarList = (ITaskbarList4)new TaskbarList();
        taskbarList.HrInit();

        taskbarList.ActivateTab((HWND)form.Handle);
    }

    /// <summary>
    ///  Adds an item to the taskbar.
    /// </summary>
    public static void AddTab(this Form form)
    {
        ITaskbarList4 taskbarList = (ITaskbarList4)new TaskbarList();
        taskbarList.HrInit();

        taskbarList.AddTab((HWND)form.Handle);
    }

    /// <summary>
    ///  Deletes an item from the taskbar.
    /// </summary>
    public static void DeleteTab(this Form form)
    {
        ITaskbarList4 taskbarList = (ITaskbarList4)new TaskbarList();
        taskbarList.HrInit();

        taskbarList.DeleteTab((HWND)form.Handle);
    }

    /// <summary>
    ///  Marks a window as full-screen.
    /// </summary>
    /// <param name="fullScreen">The desired full-screen status of the window.</param>
    public static void MarkFullscreenWindow(this Form form, bool fullScreen)
    {
        ITaskbarList4 taskbarList = (ITaskbarList4)new TaskbarList();
        taskbarList.HrInit();

        taskbarList.MarkFullscreenWindow((HWND)form.Handle, fullScreen);
    }

    /// <summary>
    ///  Marks a taskbar item as active but does not visually activate it.
    /// </summary>
    public static void SetActiveAlt(this Form form)
    {
        ITaskbarList4 taskbarList = (ITaskbarList4)new TaskbarList();
        taskbarList.HrInit();

        taskbarList.SetActiveAlt((HWND)form.Handle);
    }

    /// <summary>
    ///  Applies an overlay to a taskbar item to indicate application status or a notification to the user.
    /// </summary>
    /// <param name="icon">The icon to use as the overlay.</param>
    /// <param name="description">A string that provides an alt text version of the information conveyed by the overlay, for accessbility
    /// purposes.</param>
    public static void SetOverlayIcon(this Form form, Icon? icon, string description)
    {
        ITaskbarList4 taskbarList = (ITaskbarList4)new TaskbarList();
        taskbarList.HrInit();

        unsafe
        {
            fixed (char* pszDescription = description)
            {
                taskbarList.SetOverlayIcon(
                    (HWND)form.Handle,
                    new HICON(icon?.Handle ?? IntPtr.Zero),
                    new PCWSTR(pszDescription));
            }
        }
    }

    /// <summary>
    ///  Sets the type and state of the progress indicator displayed on a taskbar button.
    /// </summary>
    /// <param name="state">The current state of the taskbar progress button.</param>
    public static void SetProgressState(this Form form, TaskbarProgressState state)
    {
        ITaskbarList4 taskbarList = (ITaskbarList4)new TaskbarList();
        taskbarList.HrInit();

        taskbarList.SetProgressState((HWND)form.Handle, (TBPFLAG)state);
    }

    /// <summary>
    ///  Displays or updates a progress bar hosted in a taskbar button to show the specific percentage completed of the full operation.
    /// </summary>
    /// <param name="completed">An value that indicates the proportion of the operation that has been completed.</param>
    /// <param name="total">An value that specifies the value <paramref name="completed"/> will have when the operation is complete.</param>
    public static void SetProgressValue(this Form form, int completed, int total)
    {
        ITaskbarList4 taskbarList = (ITaskbarList4)new TaskbarList();
        taskbarList.HrInit();

        taskbarList.SetProgressValue((HWND)form.Handle, (ulong)completed, (ulong)total);
    }

    /// <summary>
    ///  Informs the taskbar that a tab or document window has been made the active window.
    /// </summary>
    /// <param name="handleTab">Handle of the active tab window. This handle must already be registered through
    /// <see cref="RegisterTab(nint)"/>. This value can be NULL if no tab is active.</param>
    /// <param name="handleMDI">Handle of the application's main window. This value tells the taskbar which group the thumbnail is a member
    /// of. This value is required and cannot be NULL.</param>
    public static void SetTabActive(this Form form)
    {
        ITaskbarList4 taskbarList = (ITaskbarList4)new TaskbarList();
        taskbarList.HrInit();

        taskbarList.SetTabActive((HWND)form.Handle, (HWND)form.Handle, 0);
    }

    /// <summary>
    ///  Selects a portion of a window's client area to display as that window's thumbnail in the taskbar.
    /// </summary>
    /// <param name="rectangle">Specifies a selection within the window's client area, relative to the upper-left corner of that client
    /// area. To clear a clip that is already in place and return to the default display of the thumbnail, set this parameter to NULL.</param>
    public static void SetThumbnailClip(this Form form, Rectangle rectangle)
    {
        ITaskbarList4 taskbarList = (ITaskbarList4)new TaskbarList();
        taskbarList.HrInit();

        taskbarList.SetThumbnailClip((HWND)form.Handle, rectangle);
    }

    /// <summary>
    ///  Specifies or updates the text of the tooltip that is displayed when the mouse pointer rests on an individual preview thumbnail in
    ///  a taskbar button flyout.
    /// </summary>
    /// <param name="tooltip">The text to be displayed in the tooltip. This value can be NULL, in which case the title of the windows
    /// specified by hwnd is used as the tooltip.</param>
    public static void SetThumbnailTooltip(this Form form, string tooltip)
    {
        ITaskbarList4 taskbarList = (ITaskbarList4)new TaskbarList();
        taskbarList.HrInit();

        unsafe
        {
            fixed (char* pszTip = tooltip)
            {
                taskbarList.SetThumbnailTooltip((HWND)form.Handle, new PCWSTR(pszTip));
            }
        }
    }

    /// <summary>
    ///  Adds a thumbnail toolbar with a specified set of buttons to the thumbnail image of a window in a taskbar button flyout.
    /// </summary>
    /// <remarks>
    /// <para>
    ///  Buttons cannot be added or deleted later, so this must be the full defined set. Buttons also cannot be reordered, so their order
    ///  in the array, which is the order in which they are displayed left to right, will be their permanent order.
    /// </para>
    /// </remarks>
    /// <param name="buttons">The array of buttons to be added to the toolbar.</param>
    public static void ThumbBarAddButtons(this Form form, THUMBBUTTON[] buttons)
    {
        ITaskbarList4 taskbarList = (ITaskbarList4)new TaskbarList();
        taskbarList.HrInit();

        unsafe
        {
            fixed (THUMBBUTTON* pButton = buttons)
            {
                taskbarList.ThumbBarAddButtons((HWND)form.Handle, (uint)buttons.Length, pButton);
            }
        }
    }

    /// <summary>
    ///  Shows, enables, disables, or hides buttons in a thumbnail toolbar as required by the window's current state. A thumbnail toolbar
    ///  is a toolbar embedded in a thumbnail image of a window in a taskbar button flyout.
    /// </summary>
    /// <param name="buttons">The array of buttons to be updated.</param>
    public static void ThumbBarUpdateButtons(this Form form, THUMBBUTTON[] buttons)
    {
        ITaskbarList4 taskbarList = (ITaskbarList4)new TaskbarList();
        taskbarList.HrInit();

        unsafe
        {
            fixed (THUMBBUTTON* pButton = buttons)
            {
                taskbarList.ThumbBarUpdateButtons((HWND)form.Handle, (uint)buttons.Length, pButton);
            }
        }
    }

    /// <summary>
    ///  Specifies an image list that contains button images for a toolbar embedded in a thumbnail image of a window in a tasbar button
    ///  flyout.
    /// </summary>
    /// <param name="imageList">The handle of the image list that contains all button images to be used in the toolbar.</param>
    public static void ThumbBarSetImageList(this Form form, IntPtr imageList)
    {
        ITaskbarList4 taskbarList = (ITaskbarList4)new TaskbarList();
        taskbarList.HrInit();

        taskbarList.ThumbBarSetImageList((HWND)form.Handle, (HIMAGELIST)imageList);
    }
}
