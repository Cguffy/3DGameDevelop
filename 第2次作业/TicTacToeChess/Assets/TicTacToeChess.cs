using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeChess : MonoBehaviour
{
    // turn == 1: X;         turn == 2: O;
    private int counter = 0;
    private int turn = 1;
    private int [,]state = new int[3,3];

    private void newGame(){
        counter = 0;
        turn = 1;
        for(int i=0;i<3;i++)
            for(int j=0;j<3;j++)
                state[i,j] = 0;
    }

    // return == -1: no one wins, game continue;
    // return == 0: flow bureau;
    // return == 1: X wins;
    // return == 2: O wins;
    private int isOver(){
        // test second row and col, and two slash
        int center = state[1,1];
        if(center != 0){
            // two slash
            if((center == state[0,0] && center == state[2,2])||(center == state[0,2] && center == state[2,0]))
                return center;
            // row and col
            if((center == state[1,0] && center == state[1,2])||(center == state[0,1] && center == state[2,1]))
                return center;
        }
        
        // test first row and col
        int first = state[0,0];
        if(first != 0){
            if((first == state[1,0] && first == state[2,0])||(first == state[0,1] && first == state[0,2]))
                return first;
        }

        // test third row and col
        int last = state[2,2];
        if(last != 0){
            if((last == state[0,2] && last == state[1,2])||(last == state[2,0] && last == state[2,1]))
                return last;
        }
        
        // flow bureau
        if(counter >= 9)
            return 0;
        else
            return -1;
    }

    // Start is called before the first frame update
    void Start()
    {
        newGame();
    }

    void OnGUI()
    {
        if(GUI.Button(new Rect(350,400,200,80), "new game"))
		{
			newGame();
		}

		int gameState = isOver();

        // output the game state: continue or someone wins or flow bureau
		if (gameState == 1) {
			GUI.Label (new Rect (430, 40, 100, 50), "X wins");
		} 
		else if (gameState == 2) {
			GUI.Label (new Rect (430, 40, 100, 50), "O wins");
		} 
		else if (gameState == 0) {
			GUI.Label (new Rect (415, 40, 100, 50), "flow bureau");
		} 
		else {
			if (turn == 1) {
				GUI.Label (new Rect (370, 40, 200, 80), "Game Continue! It's X's turn");
			}
			else if (turn == 2) {
				GUI.Label (new Rect (370, 40, 200, 80), "Game Continue! It's O's turn");
			}
		}

        // print the button
		for(int i = 0; i < 3; i++)
		{
			for(int j = 0; j < 3; j++)
			{
				if (state[i, j] == 1)
                    GUI.Button(new Rect(i * 100 + 300, j * 100 + 80, 100, 100), "X");
				else if (state[i, j] == 2)
                    GUI.Button(new Rect(i * 100 + 300, j * 100 + 80, 100, 100), "O");
				if(GUI.Button(new Rect(i * 100 + 300, j * 100 + 80, 100, 100), "")){
                    // only when game continues, we can update the button and state
                    if(gameState == -1)
					{
						if (turn == 1){
                            state[i, j] = 1;
                            turn = 2;
                        }
                        else if (turn == 2){
                            state[i, j] = 2;
                            turn = 1;
                        }
                        counter++;
					}
                }
			}
		}
    }
}
