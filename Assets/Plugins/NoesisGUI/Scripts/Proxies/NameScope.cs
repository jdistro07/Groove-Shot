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

public class NameScope : BaseComponent {
  internal new static NameScope CreateProxy(IntPtr cPtr, bool cMemoryOwn) {
    return new NameScope(cPtr, cMemoryOwn);
  }

  internal NameScope(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn) {
  }

  internal static HandleRef getCPtr(NameScope obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  public object this[string key] {
    get {
      if (key == null) {
        throw new ArgumentNullException("key");
      }
      return FindName(key);
    }
    set {
      if (key == null) {
        throw new ArgumentNullException("key");
      }
      if (value == null) {
        throw new ArgumentNullException("value");
      }
      RegisterName(key, value);
    }
  }

  public NameScope() {
  }

  protected override System.IntPtr CreateCPtr(System.Type type, out bool registerExtend) {
    registerExtend = false;
    return NoesisGUI_PINVOKE.new_NameScope();
  }

  public static NameScope GetNameScope(DependencyObject element) {
    IntPtr cPtr = NoesisGUI_PINVOKE.NameScope_GetNameScope(DependencyObject.getCPtr(element));
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return (NameScope)Noesis.Extend.GetProxy(cPtr, false);
  }

  public static void SetNameScope(DependencyObject element, NameScope nameScope) {
    NoesisGUI_PINVOKE.NameScope_SetNameScope(DependencyObject.getCPtr(element), NameScope.getCPtr(nameScope));
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
  }

  public object FindName(string name) {
    IntPtr cPtr = NoesisGUI_PINVOKE.NameScope_FindName(swigCPtr, name != null ? name : string.Empty);
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return Noesis.Extend.GetProxy(cPtr, false);
  }

  public void RegisterName(string name, object obj) {
    NoesisGUI_PINVOKE.NameScope_RegisterName(swigCPtr, name != null ? name : string.Empty, Noesis.Extend.GetInstanceHandle(obj));
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
  }

  public void UnregisterName(string name) {
    NoesisGUI_PINVOKE.NameScope_UnregisterName(swigCPtr, name != null ? name : string.Empty);
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
  }

  public void UpdateName(string name, object obj) {
    NoesisGUI_PINVOKE.NameScope_UpdateName(swigCPtr, name != null ? name : string.Empty, Noesis.Extend.GetInstanceHandle(obj));
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
  }

  public static DependencyProperty NameScopeProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.NameScope_NameScopeProperty_get();
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  new internal static IntPtr GetStaticType() {
    IntPtr ret = NoesisGUI_PINVOKE.NameScope_GetStaticType();
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }

}

}

