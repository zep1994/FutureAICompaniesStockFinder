import { useParams } from "react-router-dom";

const Category = () => {
  const { name } = useParams();

  return (
    <div className="category">
      <h1>{name} Tools</h1>
      <p>Explore AI tools in the {name} category.</p>
    </div>
  );
};

export default Category;
