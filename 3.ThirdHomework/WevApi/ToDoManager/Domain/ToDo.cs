namespace ToDoManager.Domain
{
    public class ToDo
    {
        public int Id { get; init; }
        public string Title { get; init; }

        /// <summary>
        ///  День, на который запланированна ToDo
        /// </summary>

        public DateTime PlannedDay { get; init; }

        public ToDo(int id, string tittle, DateTime plannedDay)
        {
            Id = id;
            Title = tittle;
            PlannedDay = plannedDay;
        }

        public ToDo(int id, string tittle)
        {
            Id = id;
            Title = tittle;
            PlannedDay = DateTime.UtcNow;
        }
    }
}

