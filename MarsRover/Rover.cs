namespace MarsRover;

public class Rover
{
    public string Facing { get; private set; }
    public int[] Coordinates { get; }

    public Rover(string facing, int[] coordinates)
    {
        Facing = facing;
        Coordinates = coordinates;
    }

    public void Go(string instructions)
    {
        NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        logger.Info("Executing Rover instructions: " + instructions);

        foreach (var instruction in instructions.ToCharArray())
        {
            Execute(instruction);
        }
    }

    private void Execute(char instruction)
    {
        if (instruction == 'R')
        {
            if (Facing == "N")
            {
                Facing = "E";
                return;
            }

            if (Facing == "E")
            {
                Facing = "S";
                return;
            }

            if (Facing == "S")
            {
                Facing = "W";
                return;
            }

            Facing = "N";
        }

        if (instruction == 'L')
        {
            if (Facing == "N")
            {
                Facing = "W";
                return;
            }

            if (Facing == "W")
            {
                Facing = "S";
                return;
            }

            if (Facing == "S")
            {
                Facing = "E";
                return;
            }

            Facing = "N";
        }

        if (instruction == 'F')
        {
            if (Facing == "N")
            {
                Coordinates[1] = Coordinates[1] + 1;
            }

            if (Facing == "E")
            {
                Coordinates[0] = Coordinates[0] + 1;
            }

            if (Facing == "S")
            {
                Coordinates[1] = Coordinates[1] - 1;
            }

            if (Facing == "W")
            {
                Coordinates[0] = Coordinates[0] - 1;
            }
        }

        if (instruction == 'B')
        {
            if (Facing == "N")
            {
                Coordinates[1] = Coordinates[1] - 1;
            }

            if (Facing == "E")
            {
                Coordinates[0] = Coordinates[0] - 1;
            }

            if (Facing == "S")
            {
                Coordinates[1] = Coordinates[1] + 1;
            }

            if (Facing == "W")
            {
                Coordinates[0] = Coordinates[0] + 1;
            }
        }
    }
}