# Axis Offset Generator

A Windows Forms utility for generating a left- or right-offset trajectory from a whitespace-delimited axis file. The application reads the original axis points, offsets their Easting/Northing coordinates by a user-specified distance, recalculates heading for the generated axis, and exports a new axis file.

## Features

- Read an axis text file containing 12 numeric fields per point.
- Specify an offset distance in metres.
- Generate an offset on the **Left** or **Right** side of the input axis.
- Preserve the other point attributes by cloning the input records.
- Recalculate `heading[rad]` and `heading_axis[°]` for the output coordinates.
- Export the generated points to a text file.
- Parse and write numeric values using invariant culture (decimal point `.`).

## How the offset is calculated

For each input point, the program estimates a local tangent from its neighbouring points:

- First point: tangent from point 0 to point 1.
- Last point: tangent from the previous point to the last point.
- Interior point: tangent from the previous point to the next point.

The tangent is normalized. A perpendicular unit normal is then used to offset the point:

- **Left:** `(-Ty, Tx)`
- **Right:** `(Ty, -Tx)`

For input coordinate `P = (E, N)`, normalized tangent `T = (Tx, Ty)`, normal `N̂`, and offset `d`, the output coordinate is:

```text
Q = P + d × N̂
```

The generated heading is calculated from neighbouring output coordinates using:

```text
heading_rad = atan2(delta_Easting, delta_Northing)
```

Negative angles are normalized to the range `[0, 2π)`. `heading_axis[°]` is derived from the radian value.

> **Note:** This is a point-wise tangent offset. It does not enforce the original distance between consecutive output points, and sharp bends may produce kinks or self-intersections.

## Input file format

The input file is whitespace-separated and contains a header line followed by one record per point. The reader ignores the header text and expects exactly **12 numeric columns** in this order:

| # | Field | Description |
|---:|---|---|
| 1 | `distance[m]` | Distance / station value |
| 2 | `heading_axis[°]` | Axis heading in degrees |
| 3 | `easting[m]` | Easting coordinate |
| 4 | `northing[m]` | Northing coordinate |
| 5 | `time_utc[s]` | UTC time |
| 6 | `time_gps[s]` | GPS time |
| 7 | `latitude[°]` | Latitude |
| 8 | `longitude[°]` | Longitude |
| 9 | `ellipsoid_height[m]` | Ellipsoid height |
| 10 | `roll[rad]` | Roll |
| 11 | `pitch[rad]` | Pitch |
| 12 | `heading[rad]` | Heading in radians |

Blank data lines are skipped. The values must be parseable as numbers using a decimal point (`.`).

## Output file

The output has the same 12-column order and a generated header. The program retains the input values for:

- `distance[m]`
- `time_utc[s]`
- `time_gps[s]`
- `latitude[°]`
- `longitude[°]`
- `ellipsoid_height[m]`
- `roll[rad]`
- `pitch[rad]`

It updates:

- `easting[m]` and `northing[m]` — offset coordinates
- `heading[rad]` and `heading_axis[°]` — headings calculated from the output axis

Output formatting uses five decimal places for most fields and eight decimal places for latitude and longitude.

## Using the application

1. Launch **Axis_Offset.exe**.
2. Click **Browse Input** and select the source axis text file.
   - The output filename is automatically suggested in the same folder, with `_Offset` appended to the input filename.
3. Enter the required offset in metres in **Offset (m)**.
4. Select **Left** or **Right**.
5. Click **Export Axis**.
6. The generated file is written to the output path shown in the form. A completion message is displayed.

Example: `SurveyAxis.txt` produces the suggested output name `SurveyAxis_Offset.txt`.

## Build from source

### Requirements

- Windows
- Visual Studio with the **.NET desktop development** workload
- .NET Framework 4.7.2 targeting/developer pack

### Build steps

1. Open `Axis_Offset.slnx` in Visual Studio (or open `Axis_Offset.csproj`).
2. Select **Debug** or **Release** and the desired platform.
3. Build the project.
4. Run the generated `Axis_Offset.exe`.

The project is a Windows Forms application targeting **.NET Framework 4.7.2**. The x64 configurations specify **C# 7.3**.

## Project structure

```text
Axis_Offset/
├── Form1.cs                  # Windows Forms UI and processing workflow
├── Form1.Designer.cs          # UI controls and layout
├── Program.cs                 # Application entry point
├── Models/
│   └── AxisPoint.cs           # Axis point data model and Clone()
├── IO/
│   ├── AxisReader.cs          # Reads 12-column axis text files
│   └── AxisWriter.cs          # Writes generated axis files
├── Processing/
│   ├── AxisOffsetGenerator.cs # Offset generation orchestration
│   ├── TangentCalculator.cs   # Local tangent calculation
│   ├── OffsetCalculator.cs    # Left/right normal offset
│   ├── HeadingCalculator.cs   # Output heading calculation
│   └── OffsetSelector.cs      # Geometry-based candidate selection helper
├── Geometry/
│   ├── CircleIntersection.cs  # Circle intersection calculation
│   ├── GeometryHelper.cs      # Basic 2D geometry helpers
│   └── Vector2D.cs            # 2D vector class
└── Axis_Offset.csproj          # Project configuration
```

## Error handling

The reader reports an error if the input file is missing, has no header, contains a data record with other than 12 columns, or contains numeric values that cannot be parsed. The application also checks that the input file exists and that the offset value is numeric before processing.

## License

This project includes `LICENSE.txt` with the MIT License text. The copyright year and copyright holder in that file are currently placeholders and should be completed by the project owner.
