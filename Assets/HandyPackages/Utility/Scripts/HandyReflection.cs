namespace Handy.Utility{
	using System;
	using System.Reflection;

	public static class HandyReflection{

		public static T GetAttribute<T>(this MemberInfo memberInfo) where T : Attribute{
			object[] attributes = memberInfo.GetCustomAttributes (typeof(T), false);
			if (attributes.Length > 0) {
				return (T) attributes [0];
			}
			return null;
		}

		public static bool IsPropertyNumber(this MemberInfo memberInfo){
			if (memberInfo is PropertyInfo) {
				PropertyInfo propertyInfo = (PropertyInfo)memberInfo;
				TypeCode typeCode = Type.GetTypeCode(propertyInfo.PropertyType);
				switch (typeCode) {
				case TypeCode.Byte:
				case TypeCode.SByte:
				case TypeCode.UInt16:
				case TypeCode.UInt32:
				case TypeCode.UInt64:
				case TypeCode.Int16:
				case TypeCode.Int32:
				case TypeCode.Int64:
				case TypeCode.Decimal:
				case TypeCode.Double:
				case TypeCode.Single:
					return true;
				default:
					return false;
				}
			}
			return false;
		}

		public static bool IsPropertyDecimal(this MemberInfo memberInfo){
			if (memberInfo is PropertyInfo) {
				PropertyInfo propertyInfo = (PropertyInfo)memberInfo;
				TypeCode typeCode = Type.GetTypeCode(propertyInfo.PropertyType);
				switch (typeCode) {
				case TypeCode.Decimal:
				case TypeCode.Double:
				case TypeCode.Single:
					return true;
				default:
					return false;
				}
			}
			return false;
		}

	}
}