class GraphNode:
    def __init__(self, label):
        self.label = label
        self.neighbors = set()
        self.color = None

def max_degree(graph):
    return 0 if len(graph) == 0 else max([len(node.neighbors) for node in graph])

def add_edge(node_a, node_b):
    node_a.neighbors.add(node_b)
    node_b.neighbors.add(node_a)

def color(graph, colors):
    for node in graph:
        neighboring_colors = set([neighbor.color for neighbor in node.neighbors])
        available_colors = list(colors.difference(neighboring_colors))
        node.color = available_colors[0]