namespace AnimalShelter
{
    class Animal
    {
        public AnimalType Type { get; private set; }
        public Animal(AnimalType type)
        {
            this.Type = type;
        }
    }
}
