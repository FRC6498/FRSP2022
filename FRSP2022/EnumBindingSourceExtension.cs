using System;
using System.Windows.Markup;

namespace FRSP2022
{
    public class EnumBindingSourceExtension : MarkupExtension
    {
        private Type _enumType;
        public Type EnumType
        {
            get { return _enumType; }
            set
            {
                if (value != _enumType)
                {
                    if (value is not null)
                    {
                        Type enumType = Nullable.GetUnderlyingType(value) ?? value;

                        if (!enumType.IsEnum)
                        {
                            throw new ArgumentException("Type must be an Enum");
                        }
                    }
                    _enumType = value;
                }
            }
        }

        public EnumBindingSourceExtension() { }

        public EnumBindingSourceExtension(Type enumType)
        {
            EnumType = enumType;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_enumType is null)
            {
                throw new InvalidOperationException("The EnumType must be specified.");
            }

            Type realEnumType = Nullable.GetUnderlyingType(_enumType) ?? _enumType;

            Array enumValues = Enum.GetValues(realEnumType);
            if (realEnumType == _enumType)
            {
                return enumValues;
            }

            Array tempArray = Array.CreateInstance(realEnumType, enumValues.Length + 1);
            enumValues.CopyTo(tempArray, 1);
            return tempArray;
        }
    }
}
