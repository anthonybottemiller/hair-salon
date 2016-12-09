namespace HairSalon
{
  public class Stylist
  {
    private int _id;
    private string _name;

    public string GetName()
    {
      return _name;
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
        bool nameEquality = (this.GetName() == newStylist.GetName());
        return (nameEquality);
      }
    }
  }
}