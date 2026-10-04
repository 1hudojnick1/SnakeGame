using System;
using System.Collections.Generic;

public class SnakeGameplayState : BaseGameState
{
    public struct Cell
    {
        public int X;
        public int Y;

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public enum SnakeDir
    {
        Up,
        Down,
        Left,
        Right
    }

    private List<Cell> Body = new List<Cell>();

    private SnakeDir currentDir;

    private float timeToMove;

    public void SetDirection(SnakeDir dir)
    {
        currentDir = dir;
    }

    private Cell ShiftTo(Cell cell)
    {
        switch (currentDir)
        {
            case SnakeDir.Up:
                cell.Y += 1;
                break;

            case SnakeDir.Down:
                cell.Y -= 1;
                break;

            case SnakeDir.Left:
                cell.X -= 1;
                break;

            case SnakeDir.Right:
                cell.X += 1;
                break;
        }

        return cell;
    }

    public override void Update(float deltaTime)
    {
        timeToMove -= deltaTime;

        if (timeToMove > 0)
            return;

        timeToMove = 1f / 5f;

        Cell head = Body[0];

        Cell nextCell = ShiftTo(head);

        Body.RemoveAt(Body.Count - 1);

        Body.Insert(0, nextCell);

        Console.WriteLine($"X: {Body[0].X}, Y: {Body[0].Y}");
    }

    public override void Reset()
    {
        Body.Clear();

        currentDir = SnakeDir.Right;

        Body.Add(new Cell(0, 0));

        timeToMove = 0;
    }
}