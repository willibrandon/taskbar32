using System.Drawing;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.UI.Controls;
using Windows.Win32.UI.Shell;
using Windows.Win32.UI.WindowsAndMessaging;

namespace taskbar32;

/// <summary>
///  A .NET wrapper around the Windows taskbar API.
/// </summary>
public class TaskbarHelper
{
    private readonly HWND _handle;
    private readonly ITaskbarList4 _taskbarList;

    public TaskbarHelper(nint handle)
    {
        _handle = (HWND)handle;
        _taskbarList = (ITaskbarList4)new TaskbarList();
        _taskbarList.HrInit();
    }

    /// <summary>
    ///  Activates an item on the taskbar. The window is not actually activated; the window's item on the taskbar is merely displayed as active.
    /// </summary>
    /// <param name="handle"></param>
    public void ActivateTab() => _taskbarList.ActivateTab(_handle);

    /// <summary>
    ///  Adds an item to the taskbar.
    /// </summary>
    public void AddTab() => _taskbarList.AddTab(_handle);

    /// <summary>
    ///  Deletes an item from the taskbar.
    /// </summary>
    public void DeleteTab() => _taskbarList.DeleteTab(_handle);

    /// <summary>
    ///  Marks a window as full-screen.
    /// </summary>
    /// <param name="fullScreen">The desired full-screen status of the window.</param>
    public void MarkFullscreenWindow(bool fullScreen) => _taskbarList.MarkFullscreenWindow(_handle, fullScreen);

    /// <summary>
    ///  Informs the taskbar that a new tab or document thumbnail has been provided for display in an application's taskbar group flyout.
    /// </summary>
    /// <param name="handleTab">Handle of the tab or document window. This value is required and cannot be NULL.</param>
    /// <param name="handleMDI">Handle of the applciation's main window. This value tells the taskbar which application's preview group
    /// is to attach the new thumbnail too. This value is required and cannot be NULL.</param>
    public void RegisterTab(nint handleTab, nint handleMDI) => _taskbarList.RegisterTab((HWND)handleTab, (HWND)handleMDI);

    /// <summary>
    ///  Marks a taskbar item as active but does not visually activate it.
    /// </summary>
    public void SetActiveAlt() => _taskbarList.SetActiveAlt(_handle);

    /// <summary>
    ///  Applies an overlay to a taskbar item to indicate application status or a notification to the user.
    /// </summary>
    /// <param name="icon">The icon to use as the overlay.</param>
    /// <param name="description">A string that provides an alt text version of the information conveyed by the overlay, for accessbility
    /// purposes.</param>
    public void SetOverlayIcon(Icon? icon, string description)
    {
        unsafe
        {
            fixed (char* pszDescription = description)
            {
                _taskbarList.SetOverlayIcon(
                    _handle,
                    new HICON(icon?.Handle ?? IntPtr.Zero),
                    new PCWSTR(pszDescription));
            }
        }
    }

    /// <summary>
    ///  Sets the type and state of the progress indicator displayed on a taskbar button.
    /// </summary>
    /// <param name="state">The current state of the taskbar progress button.</param>
    public void SetProgressState(TaskbarProgressState state) => _taskbarList.SetProgressState(_handle, (TBPFLAG)state);

    /// <summary>
    ///  Displays or updates a progress bar hosted in a taskbar button to show the specific percentage completed of the full operation.
    /// </summary>
    /// <param name="completed">An value that indicates the proportion of the operation that has been completed.</param>
    /// <param name="total">An value that specifies the value <paramref name="completed"/> will have when the operation is complete.</param>
    public void SetProgressValue(int completed, int total) => _taskbarList.SetProgressValue(_handle, (ulong)completed, (ulong)total);

    /// <summary>
    ///  Informs the taskbar that a tab or document window has been made the active window.
    /// </summary>
    /// <param name="handleTab">Handle of the active tab window. This handle must already be registered through
    /// <see cref="RegisterTab(nint)"/>. This value can be NULL if no tab is active.</param>
    /// <param name="handleMDI">Handle of the application's main window. This value tells the taskbar which group the thumbnail is a member
    /// of. This value is required and cannot be NULL.</param>
    public void SetTabActive(nint handleTab, nint handleMDI) => _taskbarList.SetTabActive((HWND)handleTab, (HWND)handleMDI, 0);

    /// <summary>
    ///  Inserts a new thumbnail into a tabbed-document interface (TDI) or multiple-document interface (MDI) application's group flyout or
    ///  moves an existing thumbnail to a new position in the application's group.
    /// </summary>
    /// <param name="handleTab">The handle of the tab window whose thumbnail is being placed. This value is required, must already be
    /// registered through <see cref="RegisterTab(nint)"/>, and cannot be NULL.</param>
    /// <param name="handleInsertBefore">The handle of the tab window whose thumbnail that <paramref name="handleTab"/> is inserted to the
    /// left of. This handle must already be registered through <see cref="RegisterTab(nint)"/>. If this value is NULL, the new thumbnail
    /// is added to the end of the list.</param>
    public void SetTabOrder(nint handleTab, nint handleInsertBefore) => _taskbarList.SetTabOrder((HWND)handleTab, (HWND)handleInsertBefore);

    /// <summary>
    ///  Selects a portion of a window's client area to display as that window's thumbnail in the taskbar.
    /// </summary>
    /// <param name="rectangle">Specifies a selection within the window's client area, relative to the upper-left corner of that client
    /// area. To clear a clip that is already in place and return to the default display of the thumbnail, set this parameter to NULL.</param>
    public void SetThumbnailClip(Rectangle rectangle) => _taskbarList.SetThumbnailClip(_handle, rectangle);

    /// <summary>
    ///  Specifies or updates the text of the tooltip that is displayed when the mouse pointer rests on an individual preview thumbnail in
    ///  a taskbar button flyout.
    /// </summary>
    /// <param name="tooltip">The text to be displayed in the tooltip. This value can be NULL, in which case the title of the windows
    /// specified by hwnd is used as the tooltip.</param>
    public void SetThumbnailTooltip(string tooltip)
    {
        unsafe
        {
            fixed (char* pszTip = tooltip)
            {
                _taskbarList.SetThumbnailTooltip(_handle, new PCWSTR(pszTip));
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
    public void ThumbBarAddButtons(THUMBBUTTON[] buttons)
    {
        unsafe
        {
            fixed (THUMBBUTTON* pButton = buttons)
            {
                _taskbarList.ThumbBarAddButtons(_handle, (uint)buttons.Length, pButton);
            }
        }
    }

    /// <summary>
    ///  Shows, enables, disables, or hides buttons in a thumbnail toolbar as required by the window's current state. A thumbnail toolbar
    ///  is a toolbar embedded in a thumbnail image of a window in a taskbar button flyout.
    /// </summary>
    /// <param name="buttons">The array of buttons to be updated.</param>
    public void ThumbBarUpdateButtons(THUMBBUTTON[] buttons)
    {
        unsafe
        {
            fixed (THUMBBUTTON* pButton = buttons)
            {
                _taskbarList.ThumbBarUpdateButtons(_handle, (uint)buttons.Length, pButton);
            }
        }
    }

    /// <summary>
    ///  Specifies an image list that contains button images for a toolbar embedded in a thumbnail image of a window in a tasbar button
    ///  flyout.
    /// </summary>
    /// <param name="imageList">The handle of the image list that contains all button images to be used in the toolbar.</param>
    public void ThumbBarSetImageList(IntPtr imageList) => _taskbarList.ThumbBarSetImageList(_handle, (HIMAGELIST)imageList);

    /// <summary>
    ///  Removes a thumbnail from an application's preview group when that tab or document is closed in the application.
    /// </summary>
    /// <param name="handleTab">The handle of the tab windows whose thumbnail is being removed. This is the same values which the thumbnail
    /// was registered as part of the group through <see cref="RegisterTab(nint)"/>. This value is required and cannot be NULL.</param>
    public void UnregisterTab(nint handleTab) => _taskbarList.UnregisterTab((HWND)handleTab);
}
