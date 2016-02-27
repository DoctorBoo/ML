using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Chapter6TicTacToe.Game;

namespace Chapter6TicTacToe.Players.MinMax
{
    class PlayerMinMax: Player
    {
	/// <summary>
	/// Current AI player
	/// </summary>
	private int _player = TicTacToe.EMPTY;

	public Move getMove( int[,] board,  Move prev,  int color) {

		this._player = color;

		 Node root = new Node(board, prev);
		int max = int.MinValue;

		//Node child;
		Node bestNode = null;

        //while ((child = root.getChild()) != null) {
        foreach (var child in root.Successors(null))
        {                    		
			 int val = minimaxAB(child, true, int.MinValue,
					int.MaxValue);
			if (val >= max) {
				max = val;
				bestNode = child;
			}
		}

		return bestNode.move();

	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="n"></param>
	/// <param name="min"></param>
	/// <param name="a"></param>
	/// <param name="b"></param>
	/// <returns></returns>
	private int minimaxAB( Node n,  bool min,  int a,int b) {

		int alpha = a;
		int beta = b;

		if (n.isLeaf()) {
			return n.value(this._player);
		}

        if (alpha > beta)
            return min ? beta : alpha;
		//Node child;
        //

		if (min) {
			foreach (var child in n.Successors(null)){
				 int val = minimaxAB(child, false, alpha, beta);
				if (val < beta) {
					beta = val;
				}
			}
			return beta;
		} else {
			foreach (var child in n.Successors(null)){
				 int val = minimaxAB(child, true, alpha, beta);
				if (val > alpha) {
					alpha = val;
				}
			}
			return alpha;
		}
	}

    }
}
