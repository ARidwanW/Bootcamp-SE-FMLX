namespace GameControllerLib;

// * kita juga punya card implement dari ICard
public class Card : ICard
{
    // * ICard punya ID, SideA dan B, dan status
    // * mari kita tambahkan private set agar saat bermain,
    // * kartu tetap sama
    public int Id { get; private set; }

    public int SideA { get; private set; }

    public int SideB { get; private set; }

    public CardStatus cardStatus { get; set; }

    // ! Jangan sampai lupa
    // * bahwa tiap pembuatan instance akan mengenerate HashCode unique
    // * kita tidak ingin kartu itu sama
    // * jadi kita buat agar HashCode dari pembuatan instance
    // * HashCodenya adalah id cardnya
    public override int GetHashCode()
    {
        return Id;
    }

    // * setelah itu mari kita inisialisasi cardnya
    public Card(int id, int sideA, int sideB)
    {
        Id = id;
        SideA = sideA;
        SideB = sideB;
        // * kita ingin agar pertama kali card ada di deck
        cardStatus = CardStatus.OnDeck;
    }
}
