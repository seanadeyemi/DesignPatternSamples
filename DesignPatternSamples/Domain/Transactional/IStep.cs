using System.Text;

namespace DesignPatternSamples.Domain.Transactional
{

    // Step interface
    interface IStep
    {
        string Execute();
        string Rollback();
    }

    // Concrete steps
    class Step1 : IStep
    {
        public string Execute()
        {
            return "Step 1 executed";
        }

        public string Rollback()
        {
            return "Step 1 rolled back";
        }
    }

    class Step2 : IStep
    {
        public string Execute()
        {
            return "Step 2 executed";
        }

        public string Rollback()
        {
            return "Step 2 rolled back";
        }
    }

    class Step3 : IStep
    {
        public string Execute()
        {
            return "Step 3 executed";
        }

        public string Rollback()
        {
            return "Step 3 rolled back";
        }
    }

    // Transactional class
    class TransactionalProcess
    {
        private List<IStep> steps = new List<IStep>();

        public void AddStep(IStep step)
        {
            steps.Add(step);
        }

        public string Execute()
        {
            bool success = true;
            StringBuilder status = new StringBuilder();

            foreach (var step in steps)
            {
                try
                {
                    var result = step.Execute();
                    status.AppendLine(result);
                }
                catch
                {
                    success = false;
                    break;
                }
            }

            if (!success)
            {
                Rollback();
                status.AppendLine("Rolled Back all");
            }

            return status.ToString();
        }

        private void Rollback()
        {
            for (int i = steps.Count - 1; i >= 0; i--)
            {
                steps[i].Rollback();
            }
        }
    }
}
