using MindBetter.Core.Extensions;

namespace MindBetter.Core.Model
{
    public abstract class EnumBaseEntity<T> where T : Enum
    {
        public virtual T EnumVal { get; set; }

        public virtual string Name { get; set; }  

        public string Description { get; set; }

        public EnumBaseEntity (T enumVal)
        {
            EnumVal = enumVal;
            Name = enumVal.ToString();
            Description = EnumExtensions.GetDescription(enumVal) ?? string.Empty; 
        }

        public override bool Equals(object? other)
        {
            if (other is null)
            {
                return false;
            }

            if (this.GetType() != other.GetType())
            {
                return false;
            }

            var typedOther = (EnumBaseEntity<T>) other;
            
            return this.EnumVal.Equals(typedOther.EnumVal);
        }

        public override int GetHashCode()
        {
            return (int)(object)this.EnumVal;
        }

    }
}
