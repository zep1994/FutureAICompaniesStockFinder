import { Link } from "react-router-dom";
import ToolCard from "../components/ToolCard";

const dummyTools = [
  { id: 1, name: "AI Writer", description: "Generate high-quality text automatically." },
  { id: 2, name: "AI Video Editor", description: "Enhance and edit videos using AI." },
];

const Home = () => {
  return (
    <div className="home">
      <h1>Discover the Best AI Tools</h1>
      <p>Explore AI-powered productivity, video editing, and more.</p>

      <div className="tool-grid">
        {dummyTools.map((tool) => (
          <ToolCard key={tool.id} tool={tool} />
        ))}
      </div>

      <Link to="/category/productivity" className="cta-button">Browse Productivity Tools →</Link>
    </div>
  );
};

export default Home;
