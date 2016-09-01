# Adjacent Cell

You have a 3x4 grid with letters A-L label on it as shown in the image below and each corner are grayed out, not a usable cell.

| ~~A~~     | B       | ~~C~~     |
| -         |:-:      | -:        |
| ** D **   | ** E ** | ** F **   |
| ** G **   | ** H ** | ** I **   |
| **~~J~~** | ** K ** | **~~L~~** |

If you were to fill-up the grid from numbers 1-8 from cell B D E F G H I and K, can you formulate an algorithm and logic to populate and check if the numbers have adjacent number.

You also have to display the grid if there are no adjacent numbers.

Sample grids below are wrong:

|  ~~-~~    | 4       |   ~~-~~   |
| -         |:-:      | -:        |
| **~~D~~**   | **5** | **~~F~~**   |
| **~~G~~**   | **~~H~~** | **~~I~~**   |
| ~~-~~ | **~~K~~** |  ~~-~~  |

|  ~~-~~    | ~~B~~       |   ~~-~~   |
| -         |:-:      | -:        |
| **~~D~~**   | **2** | **~~F~~**   |
| **3**   | **~~H~~** | **~~I~~**   |
| ~~-~~ | **~~K~~** |  ~~-~~  |

|  ~~-~~    | ~~B~~       |   ~~-~~   |
| -         |:-:      | -:        |
| **~~D~~**   | **~~E~~** | **~~F~~**   |
| **~~G~~**   | **7** | **8**   |
| ~~-~~ | **~~K~~** |  ~~-~~  |
