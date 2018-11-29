import unittest
import coloring
from sets import Set

class GraphColoringTest(unittest.TestCase):
    # def test_max_degree_of_empty_is_zero(self):
    #     graph = []
    #     self.assertEquals(coloring.max_degree(graph), 0)

    # def test_max_degree(self):
    #     a = coloring.GraphNode('a')
    #     b = coloring.GraphNode('b')
    #     c = coloring.GraphNode('c')
        
    #     coloring.add_edge(a, b)
    #     coloring.add_edge(b, c)

    #     graph = [a, b, c]

    #     self.assertEquals(coloring.max_degree(graph), 2)

    def test_single_node_is_colored(self):
        a = coloring.GraphNode('a')
        graph = [a]
        colors = set('red')
        coloring.color(graph, colors)
        self.assertTrue(GraphSolver().no_colors_touch(graph))

    def test_two_nodes_colors_dont_touch(self):
        a = coloring.GraphNode('a')
        b = coloring.GraphNode('b')
        coloring.add_edge(a, b)

        graph = [a, b]
        colors = Set(['red', 'blue'])
        
        coloring.color(graph, colors)
        self.assertTrue(GraphSolver().no_colors_touch(graph))

    def test_three_nodes_colors_dont_touch(self):
        a = coloring.GraphNode('a')
        b = coloring.GraphNode('b')
        c = coloring.GraphNode('c')
        coloring.add_edge(a, b)
        coloring.add_edge(b, c)

        graph = [a, b, c]
        colors = Set(['red', 'blue'])
        
        coloring.color(graph, colors)
        self.assertTrue(GraphSolver().no_colors_touch(graph))

    def test_complex_case_colors_dont_touch(self):
        a = coloring.GraphNode('a')
        b = coloring.GraphNode('b')
        c = coloring.GraphNode('c')
        d = coloring.GraphNode('d')
        e = coloring.GraphNode('e')
        f = coloring.GraphNode('f')
        g = coloring.GraphNode('g')
        h = coloring.GraphNode('h')
        i = coloring.GraphNode('i')
        j = coloring.GraphNode('j')
        k = coloring.GraphNode('k')
        l = coloring.GraphNode('l')
        
        coloring.add_edge(a, b)
        coloring.add_edge(a, c)
        coloring.add_edge(a, l)

        coloring.add_edge(c, e)

        coloring.add_edge(d, b)
        coloring.add_edge(d, f)
        coloring.add_edge(d, i)

        coloring.add_edge(f, e)
        coloring.add_edge(f, g)

        coloring.add_edge(g, e)
        coloring.add_edge(g, h)
        
        coloring.add_edge(h, i)
        coloring.add_edge(h, k)


        coloring.add_edge(h, i)
        coloring.add_edge(h, k)

        coloring.add_edge(j, i)
        coloring.add_edge(j, k)
        coloring.add_edge(j, l)

        coloring.add_edge(k, l)

        graph = [a, b, c, d, e, f, g, h, i, j, k, l]
        colors = Set(['red', 'blue', 'green', 'yellow'])
        
        coloring.color(graph, colors)
        self.assertTrue(GraphSolver().no_colors_touch(graph))
        self.assertEquals(coloring.max_degree(graph), 3)


class GraphSolver:
    @staticmethod
    def no_colors_touch(graph):
        for node in graph:
            neighboring_colors = set([neighbor.color for neighbor in node.neighbors])
            if node.color in neighboring_colors:
                return False
        return True

if __name__ == '__main__':
    unittest.main()