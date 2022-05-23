namespace Information.Models
{
    public class ProcessNameId
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public override bool Equals(object obj)  // переопределяется, чтобы проверить разность двух множеств (класс UpdateProcessesList)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            if (obj is ProcessNameId p) 
                return Name == p.Name && Id == p.Id;
            return false;
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
