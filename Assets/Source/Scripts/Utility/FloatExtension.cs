public static class FloatExtension 
{
    public static float FindNormalize(this float current,float min,float max)
    {
        return (current - min) / (max - min);
    }
}
