namespace HairSalon
{
  public class Stylist
  {
    private int _id;
    private string _name;

  public Stylist(string Name, int Id = 0)
  {
    _id = Id;
    _name = Name;
  }

    public string GetName()
    {
      return _name;
    }

    public int GetId()
    {
      return _id;
    }
    
    public override bool Equals(System.Object otherStylist)
    {
      if (!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool idEquality = this.GetId() == newStylist.GetId();
        bool nameEquality = this.GetName() == newStylist.GetName();
        return (nameEquality && idEquality);
      }
    }
    public override int GetHashCode()
        {
            return this.GetName().GetHashCode();
        }
  }
}