export type SearchRecipe = {
    Query: string;                // Required field
    Cuisine?: string | null;     // Nullable field
    ExcludeCuisine?: string | null; // Nullable field
    Diet?: string | null;        // Nullable field
    Type?: string | null;        // Nullable field
    Sort?: string | null;        // Nullable field
    MinCarbs?: number | null;    // Nullable number field
    MaxCarbs?: number | null;    // Nullable number field
    MinCalories?: number | null; // Nullable number field
    MaxCalories?: number | null; // Nullable number field
    MinFat?: number | null;      // Nullable number field
    MaxFat?: number | null;      // Nullable number field
    Number: number;              // Required field
}