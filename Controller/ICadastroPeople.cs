namespace CadastroPeopleList
{
    public interface ICadastroPeople
    {
        void AddPerson();
        void ShowPeople();
        void SearchPersonById();
        void EditPerson();
        void RemovePerson();
        void SaveTextFile();
        void ReadDateFromFile();
    }
}