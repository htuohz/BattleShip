namespace BattleShip.Models
{
    public class Board
    {
        public const int BOARD_SIZE = 10;
        public bool[,] Cells {get;set;}

        public Board(){
            this.Cells = new bool[BOARD_SIZE,BOARD_SIZE];
            //Initialize the board with every cell false
            for(int i=0;i<BOARD_SIZE;i++){
                for(int j=0;j<BOARD_SIZE;j++){
                    this.Cells[i,j] = false;
                }
            }
        }
    }
}