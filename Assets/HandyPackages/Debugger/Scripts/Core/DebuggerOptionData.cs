namespace Handy.Debugger{
	using System.Collections;
	using System.Collections.Generic;
	using System.Reflection;
	using UnityEngine;

	public class DebuggerOptionData : System.IComparable{
		
		public string optionDisplayName;
		public int sortingOrder;
		public MemberInfo memberInfo;

		public bool IsProperty{
			get {
				if (memberInfo != null) {
					return memberInfo is PropertyInfo;
				}
				return false;
			}
		}
		public bool IsMethod{
			get {
				if (memberInfo != null) {
					return memberInfo is MethodInfo;
				}
				return false;
			}
		}

		#region IComparable implementation
		public int CompareTo (object obj)
		{
			DebuggerOptionData val = (DebuggerOptionData) obj;
			return this.sortingOrder.CompareTo (val);
		}
		#endregion

		public object GetValue(){
			if (IsProperty) {
				PropertyInfo p = (PropertyInfo) memberInfo;
				return p.GetGetMethod ().Invoke (DebuggerOptions.Current, null);
			}
			return default(object);
		}

		public void SetValue(object val){
			if (IsProperty) {
				PropertyInfo p = (PropertyInfo) memberInfo;
				try {
					object realValue = System.Convert.ChangeType (val, p.PropertyType);
					p.GetSetMethod ().Invoke(DebuggerOptions.Current, new object[] { realValue });
				} catch (System.Exception ex) {
					Debug.LogError ("Cannot Change Value\n" + ex.StackTrace);
				}
			}
		}

		public void AddValue(object addition){
			if (IsProperty) {
				PropertyInfo p = (PropertyInfo) memberInfo;
				try {
					System.TypeCode typeCode = System.Type.GetTypeCode(p.PropertyType);
					switch (typeCode) {
					case System.TypeCode.UInt16:
					case System.TypeCode.UInt32:
					case System.TypeCode.UInt64:
					case System.TypeCode.Int16:
					case System.TypeCode.Int32:
					case System.TypeCode.Int64:
						p.GetSetMethod ().Invoke(DebuggerOptions.Current, new object[] { (int)((int) GetValue() + (float) addition) });
						break;
					case System.TypeCode.Decimal:
					case System.TypeCode.Single:
						p.GetSetMethod ().Invoke(DebuggerOptions.Current, new object[] { (float) GetValue() + (float) addition });
						break;
					case System.TypeCode.Double:
						p.GetSetMethod ().Invoke(DebuggerOptions.Current, new object[] { (double)((double) GetValue() + (float) addition) });
						break;
					default:
						break;
					}
				} catch (System.Exception ex) {
					Debug.LogError ("Cannot Add Value\n" + ex.StackTrace);
				}
			}
		}

		public void InvokeMethod(object[] parameters = null){
			if (IsMethod) {
				MethodInfo m = (MethodInfo)memberInfo;
				m.Invoke(DebuggerOptions.Current, parameters);
			}
		}
	}
}