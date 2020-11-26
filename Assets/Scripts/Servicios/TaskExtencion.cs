using System.Threading.Tasks;

public static class TaskExtencion
{
    public static async void WrapErrors(this Task task)
    {
        await task;
    }
}