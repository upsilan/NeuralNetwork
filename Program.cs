using System;

namespace Neural_Network
{
    class Program
    {
        static void Main(string[] args)
        {
            NeuralNetwork nn = new NeuralNetwork(3, 5, 2);
        }
    }


    class NeuralNetwork
    {
        Layer[] layers;
        public NeuralNetwork(params int[] layerSizes)
        {
            layers = new Layer[layerSizes.Length - 1];
            for(int i = 0; i < layers.Length - 1; i++)
            {
                layers[i] = new Layer(layerSizes[i] ,layerSizes[i + 1]);
            }
        }

        public void Forward(double[] inputs)
        {
            layers[0].Forward(inputs);
            for(int i = 1; i < layers.Length; i++)
            {
                layers[i].Forward(layers[i - 1].nodeArray);
            }
        }




        class Layer
        {
            double[,] weights;
            double[] biases;
            public double[] nodeArray;

            int n_inputs;
            int n_nodes;

            public Layer(int n_inputs, int n_nodes)
            {
                weights = new double[n_nodes, n_inputs];
                biases = new double[n_nodes];
                nodeArray = new double[n_nodes];

                this.n_nodes = n_nodes;
                this.n_inputs = n_inputs;
            }

            public void Forward(double[] inputs)
            {
                //go for all nodes
                for(int i = 0; i < n_nodes; i++)
                {
                    //in each node go through all inputs
                    for(int j = 0; j < inputs.Length; j++)
                    {
                        nodeArray[i] += weights[i, j] * inputs[j];       
                    }
                    nodeArray[i] += biases[i];
                }
            }
        }
    }

}
