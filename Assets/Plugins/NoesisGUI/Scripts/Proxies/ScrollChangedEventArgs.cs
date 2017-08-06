/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.4
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */


using System;
using System.Runtime.InteropServices;

namespace Noesis
{

public class ScrollChangedEventArgs : RoutedEventArgs {
  private HandleRef swigCPtr;

  internal ScrollChangedEventArgs(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn) {
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(ScrollChangedEventArgs obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~ScrollChangedEventArgs() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          if (Noesis.Extend.Initialized) { NoesisGUI_PINVOKE.delete_ScrollChangedEventArgs(swigCPtr);}
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public float ExtentHeight {
    get {
      return GetExtentHeightHelper();
    }
  }

  public float ExtentHeightChange {
    get {
      return GetExtentHeightChangeHelper();
    }
  }

  public float ExtentWidth {
    get {
      return GetExtentWidthHelper();
    }
  }

  public float ExtentWidthChange {
    get {
      return GetExtentWidthChangeHelper();
    }
  }

  public float HorizontalChange {
    get {
      return GetHorizontalChangeHelper();
    }
  }

  public float HorizontalOffset {
    get {
      return GetHorizontalOffsetHelper();
    }
  }

  public float VerticalChange {
    get {
      return GetVerticalChangeHelper();
    }
  }

  public float VerticalOffset {
    get {
      return GetVerticalOffsetHelper();
    }
  }

  public float ViewportHeight {
    get {
      return GetViewportHeightHelper();
    }
  }

  public float ViewportHeightChange {
    get {
      return GetViewportHeightChangeHelper();
    }
  }

  public float ViewportWidth {
    get {
      return GetViewportWidthHelper();
    }
  }

  public float ViewportWidthChange {
    get {
      return GetViewportWidthChangeHelper();
    }
  }

  public ScrollChangedEventArgs(object s) : this(NoesisGUI_PINVOKE.new_ScrollChangedEventArgs(Noesis.Extend.GetInstanceHandle(s)), true) {
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
  }

  private float GetExtentHeightHelper() {
    float ret = NoesisGUI_PINVOKE.ScrollChangedEventArgs_GetExtentHeightHelper(swigCPtr);
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }

  private float GetExtentHeightChangeHelper() {
    float ret = NoesisGUI_PINVOKE.ScrollChangedEventArgs_GetExtentHeightChangeHelper(swigCPtr);
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }

  private float GetExtentWidthHelper() {
    float ret = NoesisGUI_PINVOKE.ScrollChangedEventArgs_GetExtentWidthHelper(swigCPtr);
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }

  private float GetExtentWidthChangeHelper() {
    float ret = NoesisGUI_PINVOKE.ScrollChangedEventArgs_GetExtentWidthChangeHelper(swigCPtr);
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }

  private float GetHorizontalChangeHelper() {
    float ret = NoesisGUI_PINVOKE.ScrollChangedEventArgs_GetHorizontalChangeHelper(swigCPtr);
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }

  private float GetHorizontalOffsetHelper() {
    float ret = NoesisGUI_PINVOKE.ScrollChangedEventArgs_GetHorizontalOffsetHelper(swigCPtr);
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }

  private float GetVerticalChangeHelper() {
    float ret = NoesisGUI_PINVOKE.ScrollChangedEventArgs_GetVerticalChangeHelper(swigCPtr);
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }

  private float GetVerticalOffsetHelper() {
    float ret = NoesisGUI_PINVOKE.ScrollChangedEventArgs_GetVerticalOffsetHelper(swigCPtr);
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }

  private float GetViewportHeightHelper() {
    float ret = NoesisGUI_PINVOKE.ScrollChangedEventArgs_GetViewportHeightHelper(swigCPtr);
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }

  private float GetViewportHeightChangeHelper() {
    float ret = NoesisGUI_PINVOKE.ScrollChangedEventArgs_GetViewportHeightChangeHelper(swigCPtr);
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }

  private float GetViewportWidthHelper() {
    float ret = NoesisGUI_PINVOKE.ScrollChangedEventArgs_GetViewportWidthHelper(swigCPtr);
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }

  private float GetViewportWidthChangeHelper() {
    float ret = NoesisGUI_PINVOKE.ScrollChangedEventArgs_GetViewportWidthChangeHelper(swigCPtr);
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }

}

}
