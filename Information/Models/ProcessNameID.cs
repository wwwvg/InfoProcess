namespace Information.Models
{
    public class ProcessNameID// : BindableBase
    {
        public string Name { get; set; }
        public int ID { get; set; }

        public override bool Equals(object obj)  // переопределяется, чтобы проверить разность двух множеств (класс UpdateProcessesList)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            if (obj is ProcessNameID p) 
                return Name == p.Name && ID == p.ID;
            return false;
        }

        public override int GetHashCode()
        {
            return ID;
        }
    }
}
