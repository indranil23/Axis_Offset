# Axis Offset Generator

A Windows desktop engineering utility for generating parallel offsets of axis alignments from survey and trajectory data.

## Overview

**Axis Offset Generator** is a C# Windows Forms application designed to offset axis alignment data while preserving the original stationing and associated trajectory information.

The application reads whitespace-delimited axis files, calculates offset coordinates, recalculates headings, and exports the resulting alignment in the original axis file format.

## Features

- Import whitespace-delimited axis files.
- Generate left or right offsets.
- Specify offset distance in metres.
- Calculate local tangent directions using neighbouring axis points.
- Compute perpendicular offset coordinates.
- Recalculate heading in degrees and radians.
- Preserve original station values and other trajectory attributes.
- Export generated axis alignments.
- Process large axis datasets efficiently.

## Input File Format

The application supports axis files containing the following fields:

| Field | Description |
|---|---|
| `distance[m]` | Distance along the axis |
| `heading_axis[°]` | Axis heading in degrees |
| `easting[m]` | Easting coordinate |
| `northing[m]` | Northing coordinate |
| `time_utc[s]` | UTC timestamp |
| `time_gps[s]` | GPS timestamp |
| `latitude[°]` | Latitude |
| `longitude[°]` | Longitude |
| `ellipsoid_height[m]` | Ellipsoid height |
| `roll[rad]` | Roll angle |
| `pitch[rad]` | Pitch angle |
| `heading[rad]` | Heading in radians |

The input file is whitespace-delimited and contains a header row.

## Offset Method

The application calculates the local tangent direction using neighbouring points.

For an interior point:

\[
T_i=P_{i+1}-P_{i-1}
\]

The tangent vector is normalized:

\[
\hat{T}_i=\frac{T_i}{|T_i|}
\]

The perpendicular normal vectors are calculated as follows.

**Left offset:**

\[
N_L=(-T_y,T_x)
\]

**Right offset:**

\[
N_R=(T_y,-T_x)
\]

The offset coordinates are then calculated using:

\[
Q_i=P_i+dN_i
\]

Where:

- \(P_i\) is the original axis point.
- \(Q_i\) is the generated offset point.
- \(d\) is the offset distance.
- \(N_i\) is the normalized perpendicular direction.

## Processing Workflow

1. Select the input axis file.
2. Specify the offset distance.
3. Select Left or Right.
4. Specify the output file.
5. Generate the offset alignment.
6. Export the resulting axis file.

## Output

The generated axis file retains the original:

- Distance values
- Timestamps
- Latitude and longitude
- Ellipsoid height
- Roll and pitch

The following fields are recalculated:

- Easting
- Northing
- Axis heading in degrees
- Heading in radians

## Technology

- C#
- Windows Forms
- .NET Framework 4.8
- C# 7.3
- Visual Studio

## Project Structure

```text
INDAxisTools
│
├── Models
│   └── AxisPoint.cs
│
├── IO
│   ├── AxisReader.cs
│   └── AxisWriter.cs
│
├── Processing
│   ├── TangentCalculator.cs
│   ├── OffsetCalculator.cs
│   ├── HeadingCalculator.cs
│   └── AxisOffsetGenerator.cs
│
├── Form1.cs
└── Program.cs
```

## Intended Applications

- Road alignment offset generation
- Survey trajectory processing
- Pavement survey data preparation
- CRG reference alignment preparation
- Geospatial engineering workflows

## License

See the repository license file for licensing information.
