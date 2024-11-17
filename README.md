# Chess Possible Moves Calculator

This project is a chess game feature that calculates and highlights all possible legal moves for a selected chess piece. It also highlights enemy pieces in red if they can be captured. The project is developed in **Unity 2020.3.X** and follows Object-Oriented Programming (OOP) principles, focusing on clean code and maintainability.

## **Features**
- **Highlight Legal Moves:** When a chess piece is selected, all the valid moves are highlighted.
- **Enemy Capture Highlighting:** If an enemy piece is within the range of a piece’s move, it is highlighted in red.
- **No Movement Logic:** This project only handles the highlighting of possible moves; actual piece movement logic is not implemented.
- **Helper Functions:** The project uses helper functions to manage chessboard tile retrieval and highlight functionality.

## **Project Setup**

### **Unity Version**
This project uses Unity **2020.3.X**. It is recommended to open the project using this version or a compatible version.

### **Folder Structure**
The project follows a standard Unity folder structure:
- **Assets:** Contains all project files like scripts, prefabs, and scenes.
- **Packages:** Includes Unity package dependencies required for the project.
- **Project Settings:** Stores project-specific configurations for Unity.

### **Game Orientation**
The game orientation is set to **Landscape**.

### **Helper Functions**
- `GetTile(row, column)`: Retrieves the tile (game object) from the chessboard at the specified row and column.
- `Highlight(row, column)`: Highlights the specified tile on the chessboard.
- `ClearHighlights()`: Clears all highlighted tiles from the chessboard.

### **Changing Initial Positions**
To adjust the starting positions of pieces:
- Modify the **row** and **column** values directly in the Unity inspector for each chess piece.

## **Instructions to Run**
1. Clone or download the repository to your local machine.
2. Open the project in **Unity 2020.3.X** or higher.
3. Play the scene to test the functionality.
4. Select a chess piece to highlight its possible legal moves.
5. The enemy pieces within range for capture will be highlighted in red.
6. Modify the row and column values in the inspector to change the starting positions for testing.

## **Contributing**
Contributions to improve the project are welcome. If you'd like to contribute:
1. Fork the repository.
2. Create a feature branch (`git checkout -b feature-branch`).
3. Commit your changes (`git commit -am 'Add feature'`).
4. Push to the branch (`git push origin feature-branch`).
5. Create a new Pull Request.


## **Contact**
If you have any questions or issues regarding the project, feel free to open an issue in the repository or contact the project owner directly.

Happy coding! 🎮
