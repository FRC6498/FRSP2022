using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Windows.Data;

namespace FRSP2022
{
    public class EnumValueConverter : IValueConverter
    {
        private string GetEnumDescription(Enum enumObject)
        {
            if (enumObject is null)
            {
                return string.Empty;
            }
            FieldInfo fieldInfo = enumObject.GetType().GetField(enumObject.ToString());
            object[] attribArray = fieldInfo.GetCustomAttributes(false);
            if (attribArray.Length is 0)
            {
                return enumObject.ToString();
            }
            else
            {
                DescriptionAttribute desc = attribArray[0] as DescriptionAttribute;
                return desc.Description;
            }

        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Enum myEnum = value as Enum;
            if (myEnum is null)
            {
                return null;
            }
            string description = GetEnumDescription(myEnum);
            if (string.IsNullOrEmpty(description) is false)
            {
                return description;
            }
            return myEnum.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Empty;
        }
    }
}
