using System;
namespace BattleShip.Models
{
    public class Ship
    {
        public const int VERTICAL = 0;
        public const int HORIZONTAL = 1;
        public int Size;

        public int Orientation;

        public Ship(int Size, int Orientation){
            if(Size<1 || Size>Board.BOARD_SIZE || Orientation>1 || Orientation<0 ){
                throw new ArgumentOutOfRangeException("Invalid argument");
            }
            this.Size = Size;
            this.Orientation = Orientation;
        }
    }
}